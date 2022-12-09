using IFS.DB.OpenAPI.Client.AccountApplication.UpdateOnboarding;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.AccountApplications
{
    public interface IUpdateKYCOnboardingAccountApplicationService
    {
        Task<APIActionResult<UpdateOnboardingAccountApplicationResponse>> DoActionAsync(UpdateOnboardingAccountApplicationRequest request);
    }

    public class UpdateKYCOnboardingAccountApplicationService : BaseAPIService, IUpdateKYCOnboardingAccountApplicationService
    {
        public UpdateKYCOnboardingAccountApplicationService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }

        public async Task<APIActionResult<UpdateOnboardingAccountApplicationResponse>> DoActionAsync(UpdateOnboardingAccountApplicationRequest request)
        {
            string apiPath = APIConstant.EndPoint.AccountApplication.UpdateOnboarding;
            HttpResponseMessage resultResponse = await _DigitalBankingOpenAPIClient.PutAsJsonAsync(apiPath, request);
            return await resultResponse.AsActionResultAsync<UpdateOnboardingAccountApplicationResponse>();
        }
    }
}
