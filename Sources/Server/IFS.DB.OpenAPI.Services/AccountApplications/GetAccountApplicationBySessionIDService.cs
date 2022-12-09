using System.Net.Http;
using System.Threading.Tasks;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.AccountApplication.GetBySessionId;
using IFS.DB.OpenAPI.Services.Common;
using IFS.DB.OpenAPI.Services.Base;

namespace IFS.DB.OpenAPI.Services.AccountApplications
{
    public interface IGetAccountApplicationBySessionIDService
    {
        Task<APIActionResult<GetAccountApplicationBySessionIdResponse>> DoActionAsync(string sessionId);
    }

    public class GetAccountApplicationBySessionIDService : BaseAPIService, IGetAccountApplicationBySessionIDService
    {
        public GetAccountApplicationBySessionIDService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }

        public async Task<APIActionResult<GetAccountApplicationBySessionIdResponse>> DoActionAsync(string sessionId)
        {
            string apiPath = APIConstant.EndPoint.AccountApplication.GetBySessionId.Replace(@"{sessionId}", sessionId);

            var httpResponseMsg = await _DigitalBankingOpenAPIClient.GetAsync(apiPath);

            return await httpResponseMsg.AsActionResultAsync<GetAccountApplicationBySessionIdResponse>();
        }
    }
}
