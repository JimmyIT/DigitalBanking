using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Parameters.GetByKey;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Parameters
{
    public interface IGetParameterService
    {
        Task<APIActionResult<GetParameterByKeyResponse>> GetByPasswordStrengthAsync();
        Task<APIActionResult<GetParameterByKeyResponse>> GetOnboardingProductionAsync();
        Task<APIActionResult<GetParameterByKeyResponse>> GetAmltracApprovalModeAsync();
        Task<APIActionResult<GetParameterByKeyResponse>> GetBankHomePageAsync();
        Task<APIActionResult<GetParameterByKeyResponse>> GetDocumentUploadFolderAsync();
        Task<APIActionResult<GetParameterByKeyResponse>> GetDocumentSizeLimitAsync();
        Task<APIActionResult<GetParameterByKeyResponse>> GetInitVectorAsync();
        Task<APIActionResult<GetParameterByKeyResponse>> GetSendiBankCustomerRegistrationNotificationAsync();
    }

    public class GetParameterService : BaseAPIService, IGetParameterService
    {
        public GetParameterService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<APIActionResult<GetParameterByKeyResponse>> GetByPasswordStrengthAsync()
            => await GetAsync(ParamKeyConst.PasswordStrength);

        public async Task<APIActionResult<GetParameterByKeyResponse>> GetAmltracApprovalModeAsync()
            => await GetAsync(ParamKeyConst.AMLApprovedMode);

        public async Task<APIActionResult<GetParameterByKeyResponse>> GetBankHomePageAsync()
            => await GetAsync(ParamKeyConst.BankHomePage);

        public async Task<APIActionResult<GetParameterByKeyResponse>> GetDocumentUploadFolderAsync()
            => await GetAsync(ParamKeyConst.DocumentUploadFolder);

        public async Task<APIActionResult<GetParameterByKeyResponse>> GetDocumentSizeLimitAsync()
            => await GetAsync(ParamKeyConst.DocumentSizeLimit);

        public async Task<APIActionResult<GetParameterByKeyResponse>> GetOnboardingProductionAsync()
            => await GetAsync(ParamKeyConst.OnboardingProduction);

        public async Task<APIActionResult<GetParameterByKeyResponse>> GetInitVectorAsync()
            => await GetAsync(ParamKeyConst.InitVector);

        public async Task<APIActionResult<GetParameterByKeyResponse>> GetSendiBankCustomerRegistrationNotificationAsync()
            => await GetAsync(ParamKeyConst.SendiBankCustomerRegistrationNotification);

        private async Task<APIActionResult<GetParameterByKeyResponse>> GetAsync(string paramKey)
        {
            string apiPath = APIConstant.EndPoint.Parameter.GetByKey.Replace(@"{paramKey}", paramKey);
            HttpResponseMessage httpResponseMsg = await _DigitalBankingOpenAPIClient.GetAsync(apiPath);
            return await httpResponseMsg.AsActionResultAsync<GetParameterByKeyResponse>();
        }
    }
}
