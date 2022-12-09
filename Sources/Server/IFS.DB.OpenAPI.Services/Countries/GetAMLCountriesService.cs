using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Countries.GetAML;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Countries
{
    public interface IGetAMLCountriesService
    {
        Task<APIActionResult<IEnumerable<GetAMLCountriesResponse>>> DoActionAsync();
    }

    public class GetAMLCountriesService : BaseAPIService, IGetAMLCountriesService
    {
        public GetAMLCountriesService(IHttpClientFactory httpClientFactory)
           : base(httpClientFactory)
        { }

        public async Task<APIActionResult<IEnumerable<GetAMLCountriesResponse>>> DoActionAsync()
        {
            string apiPath = APIConstant.EndPoint.Country.GetAMLCountries;
            HttpResponseMessage httpResponseMsg = await _DigitalBankingOpenAPIClient.GetAsync(apiPath);
            return await httpResponseMsg.AsActionResultAsync<IEnumerable<GetAMLCountriesResponse>>();
        }
    }
}
