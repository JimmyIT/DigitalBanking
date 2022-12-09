using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Documents.GetAMLRules;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Documents
{
    public interface IGetAMLDocumentRulesService
    {
        Task<APIActionResult<GetAMLDocumentRulesByEntityTypeResponse>> DoActionAsync(int entityTypeId);
    }

    public class GetAMLDocumentRulesService : BaseAPIService, IGetAMLDocumentRulesService
    {
        public GetAMLDocumentRulesService(IHttpClientFactory httpClientFactory)
           : base(httpClientFactory)
        { }

        public async Task<APIActionResult<GetAMLDocumentRulesByEntityTypeResponse>> DoActionAsync(int entityTypeId)
        {
            string apiPath = APIConstant.EndPoint.Document.GetAMLRulesByEntityType.Replace(@"{entityTypeId}", entityTypeId.ToString());
            HttpResponseMessage httpResponseMsg = await _DigitalBankingOpenAPIClient.GetAsync(apiPath);
            return await httpResponseMsg.AsActionResultAsync<GetAMLDocumentRulesByEntityTypeResponse>();
        }
    }
}
