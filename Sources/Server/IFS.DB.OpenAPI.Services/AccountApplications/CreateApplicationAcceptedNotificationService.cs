using IFS.DB.OpenAPI.Client.AccountApplication.CreateApplicationAcceptedNotification;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.AccountApplications
{
    public interface ICreateApplicationAcceptedNotificationService
    {
        Task<APIActionResult<CreateAccountApplicationAcceptedNotificationResponse>>
            DoActionAsync(CreateAccountApplicationAcceptedNotificationRequest request);
    }

    public class CreateApplicationAcceptedNotificationService : BaseAPIService, ICreateApplicationAcceptedNotificationService
    {
        public CreateApplicationAcceptedNotificationService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        { }


        public async Task<APIActionResult<CreateAccountApplicationAcceptedNotificationResponse>>
            DoActionAsync(CreateAccountApplicationAcceptedNotificationRequest request)
        {
            HttpResponseMessage response = await _DigitalBankingOpenAPIClient.PostAsJsonAsync(
                    requestUri: APIConstant.EndPoint.AccountApplication.CreateApplicationAcceptedNotification,
                    value: request
                );

            return await response.AsActionResultAsync<CreateAccountApplicationAcceptedNotificationResponse>();
        }
    }
}
