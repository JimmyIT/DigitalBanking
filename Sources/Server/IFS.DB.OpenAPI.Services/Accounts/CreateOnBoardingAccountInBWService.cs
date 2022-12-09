using IFS.DB.OpenAPI.Client.Accounts.CreateBWOnBoarding;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Accounts
{
    public interface ICreateOnBoardingAccountInBWService
    {
        Task<APIActionResult<CreateBWOnBoardingAccountResponse>> DoActionAsync(CreateBWOnBoardingAccountRequest request);
    }

    public class CreateOnBoardingAccountInBWService : ICreateOnBoardingAccountInBWService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public CreateOnBoardingAccountInBWService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<CreateBWOnBoardingAccountResponse>> DoActionAsync(CreateBWOnBoardingAccountRequest request)
        {
            string apiPath = APIConstant.EndPoint.Account.CreateBWOnBoarding;

            HttpResponseMessage httpResponseMessage = await _iBankOpenAPIClient.PostAsJsonAsync(apiPath, request);

            return await httpResponseMessage.AsActionResultAsync<CreateBWOnBoardingAccountResponse>();
        }
    }
}
