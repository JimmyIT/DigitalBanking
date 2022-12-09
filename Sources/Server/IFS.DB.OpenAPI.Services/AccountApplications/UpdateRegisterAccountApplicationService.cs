using IFS.DB.OpenAPI.Client.AccountApplication.UpdateRegisterOnboarding;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.AccountApplications
{
    public interface IUpdateRegisterAccountApplicationService
    {
        Task<APIActionResult<UpdateRegisterOnboardingAccountApplicationResponse>> DoActionAsync(UpdateRegisterOnboardingAccountApplicationRequest request);
    }

    public class UpdateRegisterAccountApplicationService : BaseAPIService, IUpdateRegisterAccountApplicationService
    {
        public UpdateRegisterAccountApplicationService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        { }

        public async Task<APIActionResult<UpdateRegisterOnboardingAccountApplicationResponse>> DoActionAsync(UpdateRegisterOnboardingAccountApplicationRequest request)
        {
            string apiPath = APIConstant.EndPoint.AccountApplication.UpdateRegisterOnboarding;
            HttpResponseMessage resultResponse = await _DigitalBankingOpenAPIClient.PutAsJsonAsync(apiPath, request);
            return await resultResponse.AsActionResultAsync<UpdateRegisterOnboardingAccountApplicationResponse>();
        }
    }
}
