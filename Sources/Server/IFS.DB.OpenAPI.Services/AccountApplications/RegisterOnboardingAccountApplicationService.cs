using IFS.DB.OpenAPI.Client.AccountApplication.RegisterOnboarding;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.AccountApplications
{
    public interface IRegisterOnboardingAccountApplicationService
    {
        Task<APIActionResult<RegisterOnboardingAccountApplicationResponse>> DoActionAsync();
    }

    public class RegisterOnboardingAccountApplicationService : BaseAPIService, IRegisterOnboardingAccountApplicationService
    {
        public RegisterOnboardingAccountApplicationService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        { }

        public async Task<APIActionResult<RegisterOnboardingAccountApplicationResponse>> DoActionAsync()
        {
            string apiPath = APIConstant.EndPoint.AccountApplication.RegisterOnboarding;
            HttpResponseMessage resultResponse = await _DigitalBankingOpenAPIClient.PostAsync(apiPath, null);
            return await resultResponse.AsActionResultAsync<RegisterOnboardingAccountApplicationResponse>();
        }
    }
}
