using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Notifications.SendApplicationAcceptedSMS;
using IFS.DB.OpenAPI.Services.Common;
using IFS.DB.OpenAPI.Services.Base;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Notifications
{
    public interface ISendApplicationAcceptedSMSService
    {
        Task<APIActionResult<SendApplicationAcceptedSMSResponse>> 
            DoActionAsync(SendApplicationAcceptedSMSRequest request);
    }

    public class SendApplicationAcceptedSMSService : BaseAPIService, ISendApplicationAcceptedSMSService
    {
        public SendApplicationAcceptedSMSService(IHttpClientFactory httpClientFactory) 
            : base(httpClientFactory)
        { }

        public async Task<APIActionResult<SendApplicationAcceptedSMSResponse>> DoActionAsync(SendApplicationAcceptedSMSRequest request)
        {
            HttpResponseMessage httpResponseMsg = await _DigitalBankingOpenAPIClient.PostAsJsonAsync(
                    requestUri: APIConstant.EndPoint.Notification.SendApplicationAcceptedSMS, 
                    value: request
                );

            return await httpResponseMsg.AsActionResultAsync<SendApplicationAcceptedSMSResponse>();
        }
    }
}
