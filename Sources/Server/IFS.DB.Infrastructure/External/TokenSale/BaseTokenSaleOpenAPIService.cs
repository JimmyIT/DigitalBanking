using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TagTokenSales.OpenAPI.Client.Constants;
using TagTokenSales.OpenAPI.Client.OpenAPI.Token;

namespace IFS.DB.Infrastructure.External.TokenSale
{
    public class BaseTokenSaleOpenAPIService
    {
        protected readonly IParameterService _ParameterSvc;
        protected readonly IStringProvider _StringProvider;

        private HttpClient _HttpClient;

        private string _APIBaseURL = string.Empty;
        private string _AccessToken = "";

        public BaseTokenSaleOpenAPIService(IParameterService parameterSvc,
            IStringProvider stringProvider)
        {
            _ParameterSvc = parameterSvc;
            _StringProvider = stringProvider;
        }

        #region Protected Functions
        protected async Task<ActionResult<T>> GetAsync<T>(string apiRoute)
        {
            await SetupConfig();

            //Post request and get respone
            HttpResponseMessage response = await _HttpClient.GetAsync(apiRoute);

            //Deserialize  Response
            return DeserializeResponse<T>(response);
        }

        protected async Task<ActionResult<T>> POSTAsync<T>(string apiRoute, string msgBody)
        {
            await SetupConfig();

            //Set i-demportancy-key Header
            _HttpClient.DefaultRequestHeaders.Add("x-idempotency-key", _StringProvider.NewGuid().ToString());

            //Set up request content
            HttpContent requestContent = new StringContent(msgBody, Encoding.UTF8, "application/Json");

            //Post request and get respone
            HttpResponseMessage response = await _HttpClient.PostAsync(apiRoute, requestContent);

            //Deserialize  Response
            return DeserializeResponse<T>(response);
        }

        protected async Task<ActionResult<T>> PUTAsync<T>(string apiRoute, string msgBody)
        {
            await SetupConfig();

            //Set i-demportancy-key Header
            _HttpClient.DefaultRequestHeaders.Add("x-idempotency-key", _StringProvider.NewGuid().ToString());

            //Set up request content
            HttpContent requestContent = new StringContent(msgBody, Encoding.UTF8, "application/Json");

            //Post request and get respone
            HttpResponseMessage response = await _HttpClient.PutAsync(apiRoute, requestContent);

            //Deserialize  Response
            return DeserializeResponse<T>(response);
        }
        #endregion

        #region Private Functions
        private async Task SetupConfig()
        {
            _HttpClient = new HttpClient();

            _APIBaseURL = await _ParameterSvc.GetTokenSaleOpenAPIURLAsync();

            //Get access token
            _AccessToken = await GetClientToken();

            //Create Http Client
            _HttpClient = CreateHttpClient();
        }

        private async Task<string> GetClientToken()
        {
            string tokenData = string.Empty;

            HttpClientHandler requestHandler = new HttpClientHandler();

            using (var client = new HttpClient(requestHandler, false))
            {
                //Initiate base root url
                client.BaseAddress = new Uri(_APIBaseURL);

                //Clear accept header
                client.DefaultRequestHeaders.Accept.Clear();

                TokenRequest tokenPostData = new TokenRequest()
                {
                    Username = await _ParameterSvc.GetTokenSaleOpenAPIUsernameAsync(),
                    Password = await _ParameterSvc.GetTokenSaleOpenAPIPasswordAsync()
                };

                HttpContent requestContent = new StringContent(JsonConvert.SerializeObject(tokenPostData), Encoding.UTF8, "application/Json");

                //Get token from api
                HttpResponseMessage response = await client.PostAsync(new Uri($"{_APIBaseURL}/{APIConstant.EndPoint.Auth}"), requestContent);
                if (response.IsSuccessStatusCode)
                    tokenData = response.Content.ReadAsStringAsync().Result;
                else
                    throw new Exception($"No such host is known. ({_APIBaseURL})");
            }

            return DeserializeToken(tokenData);
        }

        private string DeserializeToken(string tokenData)
        {
            //Serialize happen here            
            Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(tokenData);
            string token = "";

            if (values.ContainsKey("access_token"))
                token = values["access_token"].ToString();
            return token;
        }

        private HttpClient CreateHttpClient()
        {
            HttpClientHandler requestHandler = new HttpClientHandler();
            HttpClient client = new HttpClient(requestHandler, false);

            client.BaseAddress = new Uri(_APIBaseURL);
            client.DefaultRequestHeaders.Accept.Clear();

            //Set up token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken);

            //Set up header
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private ActionResult<T> DeserializeResponse<T>(HttpResponseMessage response)
        {
            ActionResult<T> result = new ActionResult<T>();

            //Check success
            if (response.IsSuccessStatusCode)
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    result.Result = (T)(object)true;
                else
                    result.Result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            else
                result.Validation = new ValidationResult(JsonConvert.DeserializeObject<IList<Error>>(response.Content.ReadAsStringAsync().Result));

            return result;
        }
        #endregion
    }
}
