using IFS.DB.OpenAPI.Client.Clients.ApproveAML;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Clients
{
    public interface ICallAMLApproveService
    {
        Task<APIActionResult<ApproveAMLClientResponse>> DoActionAsync(ApproveAMLClientRequest request);
    }

    public class CallAMLApproveService : BaseAPIService, ICallAMLApproveService
    {
        public CallAMLApproveService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<APIActionResult<ApproveAMLClientResponse>> DoActionAsync(ApproveAMLClientRequest request)
        {
            string apiPath = APIConstant.EndPoint.Client.ApproveAML;

            HttpResponseMessage httpResponseMsg = await _DigitalBankingOpenAPIClient.PutAsJsonAsync(apiPath, request);

            return await httpResponseMsg.AsActionResultAsync<ApproveAMLClientResponse>();
        }
    }
}
