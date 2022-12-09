using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Messages.Create;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.MQMessages
{
    public interface IMQMessageService
    {
        Task<APIActionResult<CreateMessageResponse>> DoActionAsync(CreateMessageRequest request);
    }
    public class CreateMessageService : IMQMessageService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public CreateMessageService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<CreateMessageResponse>> DoActionAsync(CreateMessageRequest request)
        {
            string apiPath = APIConstant.EndPoint.Message.Create;

            HttpResponseMessage httpResponseMsg = await _iBankOpenAPIClient.PostAsJsonAsync(apiPath, request);

            return await httpResponseMsg.AsActionResultAsync<CreateMessageResponse>();
        }
    }
}
