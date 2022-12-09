using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Currencies.GetAML;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Currencies
{
    public interface IGetAMLCurrenciesService
    {
        Task<APIActionResult<IEnumerable<GetAMLCurrenciesResponse>>> DoActionAsync();
    }

    public class GetAMLCurrenciesService : BaseAPIService, IGetAMLCurrenciesService
    {
        public GetAMLCurrenciesService(IHttpClientFactory httpClientFactory)
           : base(httpClientFactory)
        { }

        public async Task<APIActionResult<IEnumerable<GetAMLCurrenciesResponse>>> DoActionAsync()
        {
            string apiPath = APIConstant.EndPoint.Currency.GetAML;
            HttpResponseMessage httpResponseMsg = await _DigitalBankingOpenAPIClient.GetAsync(apiPath);
            return await httpResponseMsg.AsActionResultAsync<IEnumerable<GetAMLCurrenciesResponse>>();
        }
    }
}
