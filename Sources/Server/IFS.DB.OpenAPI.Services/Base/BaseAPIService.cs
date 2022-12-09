using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;

namespace IFS.DB.OpenAPI.Services.Base
{
    public class BaseAPIService
    {
        protected readonly HttpClient _DigitalBankingOpenAPIClient;

        public BaseAPIService(IHttpClientFactory httpClientFactory)
        {
            _DigitalBankingOpenAPIClient = httpClientFactory.CreateClient(IBankAPIConfig.CLIENT_NAME);
        }

    }
}
