using IFS.DB.OpenAPI.Client.ChartOfAccounts.GetOnlineAvailableByEntityType;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.OnlineAvailableCOAs
{
    public interface IGetOnlineAvailableCOAsService
    {
        Task<APIActionResult<IEnumerable<GetOnlineAvailableCOAByEntityTypeResponse>>> DoActionAsync(int entitypeId);
    }

    public class GetOnlineAvailableCOAsService : BaseAPIService, IGetOnlineAvailableCOAsService
    {
        public GetOnlineAvailableCOAsService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        { }

        public async Task<APIActionResult<IEnumerable<GetOnlineAvailableCOAByEntityTypeResponse>>> DoActionAsync(int entitypeId)
        {
            string apiPath = APIConstant.EndPoint.ChartOfAccount.GetByEntityTypeId.Replace(@"{entityType}", entitypeId.ToString());
            HttpResponseMessage httpResponseMsg = await _DigitalBankingOpenAPIClient.GetAsync(apiPath);
            return await httpResponseMsg.AsActionResultAsync<IEnumerable<GetOnlineAvailableCOAByEntityTypeResponse>>();
        }
    }
}
