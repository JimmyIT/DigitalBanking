using IFS.DB.OpenAPI.Client.ChartOfAccounts.GetOnlineCOAByEntityTypeIdForNewApp;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.OnlineAvailableCOAs
{
    public interface IGetOnlineCOAByEntityTypeIdForNewAppService
    {
        Task<APIActionResult<IEnumerable<GetOnlineCOAByEntityTypeIdForNewAppResponse>>> DoActionAsync(int entitypeId);
    }

    public class GetOnlineCOAByEntityTypeIdForNewAppService : BaseAPIService, IGetOnlineCOAByEntityTypeIdForNewAppService
    {
        public GetOnlineCOAByEntityTypeIdForNewAppService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        { }

        public async Task<APIActionResult<IEnumerable<GetOnlineCOAByEntityTypeIdForNewAppResponse>>> DoActionAsync(int entitypeId)
        {
            string apiPath = APIConstant.EndPoint.ChartOfAccount.GetOnlineCOAByEntityTypeIdForNewApp
                .Replace(@"{entityTypeId}", entitypeId.ToString());
            HttpResponseMessage httpResponseMsg = await _DigitalBankingOpenAPIClient.GetAsync(apiPath);
            return await httpResponseMsg.AsActionResultAsync<IEnumerable<GetOnlineCOAByEntityTypeIdForNewAppResponse>>();
        }
    }
}
