using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.SourcesOfIncome.GetAMLJobTypes;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.JobTypes
{
    public interface IGetAMLJobTypesService
    {
        Task<APIActionResult<IEnumerable<GetAMLJobTypesResponse>>> DoActionAsync();
    }

    public class GetAMLJobTypesService : BaseAPIService, IGetAMLJobTypesService
    {
        public GetAMLJobTypesService(IHttpClientFactory httpClientFactory)
             : base(httpClientFactory)
        { }

        public async Task<APIActionResult<IEnumerable<GetAMLJobTypesResponse>>> DoActionAsync()
        {
            string apiPath = APIConstant.EndPoint.SourcesOfIncome.GetAMLJobTypes;
            HttpResponseMessage httpResponseMsg = await _DigitalBankingOpenAPIClient.GetAsync(apiPath);
            return await httpResponseMsg.AsActionResultAsync<IEnumerable<GetAMLJobTypesResponse>>();
        }
    }
}
