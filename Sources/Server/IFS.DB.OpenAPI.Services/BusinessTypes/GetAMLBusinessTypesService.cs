using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.SourcesOfIncome.GetAMLBusinesses;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.BusinessTypes
{
    public interface IGetAMLBusinessTypesService
    {
        Task<APIActionResult<IEnumerable<GetAMLBusinessesResponse>>> DoActionAsync();
    }

    public class GetAMLBusinessTypesService : BaseAPIService, IGetAMLBusinessTypesService
    {
        public GetAMLBusinessTypesService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        { }

        public async Task<APIActionResult<IEnumerable<GetAMLBusinessesResponse>>> DoActionAsync()
        {
            string apiPath = APIConstant.EndPoint.SourcesOfIncome.GetAMLEmployerBusinessTypes;
            HttpResponseMessage httpResponseMsg = await _DigitalBankingOpenAPIClient.GetAsync(apiPath);
            return await httpResponseMsg.AsActionResultAsync<IEnumerable<GetAMLBusinessesResponse>>();
        }
    }
}
