using IFS.DB.OpenAPI.Client.AccountApplication.NotifyKYCApprove;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.AccountApplications
{
    public interface INotifyKYCApprovalService
    {
        Task<APIActionResult<NotifyKYCApproveResponse>> DoActionAsync(NotifyKYCApproveRequest request);
    }

    public class NotifyKYCApprovalService : BaseAPIService, INotifyKYCApprovalService
    {
        public NotifyKYCApprovalService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }

        public async Task<APIActionResult<NotifyKYCApproveResponse>> DoActionAsync(NotifyKYCApproveRequest request)
        {
            string apiPath = APIConstant.EndPoint.AccountApplication.NotifyKYCApprove;
            HttpResponseMessage resultResponse = await _DigitalBankingOpenAPIClient.PostAsJsonAsync(apiPath, request);
            return await resultResponse.AsActionResultAsync<NotifyKYCApproveResponse>();
        }
    }
}
