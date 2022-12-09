using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Notifications.SendApplicationAcceptedEmail;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Notifications
{
    public interface ISendApplicationAcceptedEmailService
    {
        Task<APIActionResult<SendApplicationAcceptedEmailResponse>> DoActionAsync(SendApplicationAcceptedEmailRequest request);
    }

    public class SendApplicationAcceptedEmailService : ISendApplicationAcceptedEmailService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public SendApplicationAcceptedEmailService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<SendApplicationAcceptedEmailResponse>> DoActionAsync(SendApplicationAcceptedEmailRequest request)
        {
            string apiPath = APIConstant.EndPoint.Notification.SendApplicationAcceptedEmail;

            HttpResponseMessage httpResponseMsg = await _iBankOpenAPIClient.PostAsJsonAsync(apiPath, request);

            return await httpResponseMsg.AsActionResultAsync<SendApplicationAcceptedEmailResponse>();
        }
    }
}
