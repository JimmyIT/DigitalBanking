using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Messages.UpdateStatus;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.MQMessages
{
    public interface IUpdateMessageStatusService
    {
        Task<APIActionResult<UpdateMessageStatusResponse>> DoActionAsync(UpdateMessageStatusRequest request);
    }

    public class UpdateMessageStatusService : IUpdateMessageStatusService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public UpdateMessageStatusService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<UpdateMessageStatusResponse>> DoActionAsync(UpdateMessageStatusRequest request)
        {
            string apiPath = APIConstant.EndPoint.Message.UpdateStatus;

            HttpResponseMessage httpResponseMessage = await _iBankOpenAPIClient.PutAsJsonAsync(apiPath, request);

            return await httpResponseMessage.AsActionResultAsync<UpdateMessageStatusResponse>();
        }
    }
}
