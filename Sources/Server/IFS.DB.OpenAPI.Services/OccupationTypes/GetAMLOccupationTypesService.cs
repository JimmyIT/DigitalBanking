using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.SourcesOfIncome.GetAMLOccupationTypes;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.OccupationTypes
{
    public interface IGetAMLOccupationTypesService
    {
        Task<APIActionResult<IEnumerable<GetAMLOccupationTypesResponse>>> DoActionAsync();
    }

    public class GetAMLOccupationTypesService : BaseAPIService, IGetAMLOccupationTypesService
    {
        public GetAMLOccupationTypesService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        { }

        public async Task<APIActionResult<IEnumerable<GetAMLOccupationTypesResponse>>> DoActionAsync()
        {
            string apiPath = APIConstant.EndPoint.SourcesOfIncome.GetAMLOccupationTypes;
            HttpResponseMessage httpResponseMsg = await _DigitalBankingOpenAPIClient.GetAsync(apiPath);
            return await httpResponseMsg.AsActionResultAsync<IEnumerable<GetAMLOccupationTypesResponse>>();
        }
    }
}
