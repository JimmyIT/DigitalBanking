using IFS.DB.OpenAPI.Services.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IFS.DB.OpenAPI.Services.ServiceCollections
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterIBankHttpClientServices(
            this IServiceCollection services,
            Action<IBankAPIConfig> configCreator
        )
        {
            if (configCreator == null)
            {
                throw new ArgumentNullException(nameof(configCreator));
            }

            IBankAPIConfig apiConfig = new IBankAPIConfig();
            configCreator.Invoke(apiConfig);

            if (string.IsNullOrEmpty(apiConfig.Url))
            {
                throw new ArgumentNullException(nameof(apiConfig.Url));
            }

            services.AddSingleton(apiConfig);
            services.AddTransient<AddAuthorizationHeaderMessageHandler>();
            services.AddTransient<AddIdempotencyKeyHeaderMessageHandler>();

            var httpClientBuilder = services.AddHttpClient(
                            IBankAPIConfig.CLIENT_NAME,
                            client => client.BaseAddress = new Uri(apiConfig.Url)
                        )
                        .AddHttpMessageHandler<AddAuthorizationHeaderMessageHandler>()
                        .AddHttpMessageHandler<AddIdempotencyKeyHeaderMessageHandler>();

            return services;

        }
    }
}
