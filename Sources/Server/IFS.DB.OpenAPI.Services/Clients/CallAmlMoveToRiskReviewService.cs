using IFS.DB.OpenAPI.Client.Clients.MoveAMLToRiskReview;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Clients
{
    public interface ICallAmlMoveToRiskReviewService
    {
        Task<APIActionResult<MoveAMLClientToRiskReviewResponse>> DoActionAsync(MoveAMLClientToRiskReviewRequest request);
    }

    public class CallAmlMoveToRiskReviewService : ICallAmlMoveToRiskReviewService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public CallAmlMoveToRiskReviewService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<MoveAMLClientToRiskReviewResponse>> DoActionAsync(MoveAMLClientToRiskReviewRequest request)
        {
            string apiPath = APIConstant.EndPoint.Client.MoveAMLToRiskReview;

            HttpResponseMessage httpResponseMsg = await _iBankOpenAPIClient.PostAsJsonAsync(apiPath, request);

            return await httpResponseMsg.AsActionResultAsync<MoveAMLClientToRiskReviewResponse>();
        }
    }
}
