using IFS.DB.OpenAPI.Client.OpenAPI.Token;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Common
{
    public sealed class AddAuthorizationHeaderMessageHandler : DelegatingHandler
    {
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private static volatile string iBankApiToken = string.Empty;

        private readonly HttpClient _httpClient;
        private readonly IBankAPIConfig _iBankAPIConfig;

        private readonly ILogger<AddAuthorizationHeaderMessageHandler> _logger;

        public AddAuthorizationHeaderMessageHandler(
            IHttpClientFactory httpClientFactory,
            IBankAPIConfig iBankAPIConfig,
            IServiceProvider service
        )
        {
            _httpClient = httpClientFactory.CreateClient();
            _iBankAPIConfig = iBankAPIConfig;
            _logger = (ILogger<AddAuthorizationHeaderMessageHandler>)
                service.GetService(typeof(ILogger<AddAuthorizationHeaderMessageHandler>));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage httpResponseMessage = default;

            if (string.IsNullOrEmpty(iBankApiToken))
            {
                await _semaphore.WaitAsync();

                if (string.IsNullOrEmpty(iBankApiToken))
                {
                    try
                    {
                        if (_httpClient.BaseAddress == null)
                        {
                            _httpClient.BaseAddress = new Uri(_iBankAPIConfig.Url);
                        }

                        AsyncRetryPolicy<HttpResponseMessage> retryPolicy = Policy
                            .Handle<HttpRequestException>()
                            .OrInner<HttpRequestException>()
                            .OrResult<HttpResponseMessage>(response => ShouldRetry(response))
                            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

                        httpResponseMessage = await retryPolicy.ExecuteAsync(
                            async () => await _httpClient.PostAsJsonAsync("token", new TokenRequest
                            {
                                Username = _iBankAPIConfig.Username,
                                Password = _iBankAPIConfig.Password
                            }));

                        if (!httpResponseMessage.IsSuccessStatusCode)
                            throw new Exception();

                        TokenResponse tokenResult = await httpResponseMessage.Content.ReadFromJsonAsync<TokenResponse>();
                        iBankApiToken = tokenResult.Access_token;
                    }
                    catch (Exception ex)
                    {
                        _logger?.LogError(new Exception("An error occurred when getting iBank OpenAPI token", ex), string.Empty); ;
                        _semaphore.Release();
                        if (httpResponseMessage != null)
                            return httpResponseMessage;
                        return ReturnServiceUnavailable(httpResponseMessage);
                    }
                }

                _semaphore.Release();
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", iBankApiToken);

            httpResponseMessage = await base.SendAsync(request, cancellationToken);

            if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized) //Token got expired
            {
                iBankApiToken = null; //Set null for next recursion check, force to fetch token again
                return await SendAsync(request, cancellationToken);
            }

            return httpResponseMessage;
        }

        private bool ShouldRetry(HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage == null
                || ((int)httpResponseMessage.StatusCode).ToString().StartsWith("5")
                || httpResponseMessage.StatusCode == HttpStatusCode.RequestTimeout;
        }

        private HttpResponseMessage ReturnServiceUnavailable(HttpResponseMessage responseMessage)
        {
            responseMessage = responseMessage ?? new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.ServiceUnavailable;
            return responseMessage;
        }
    }
}
