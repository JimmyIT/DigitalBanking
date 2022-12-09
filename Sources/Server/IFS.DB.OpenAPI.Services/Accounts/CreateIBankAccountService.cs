using IFS.DB.OpenAPI.Client.Accounts.Create;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Accounts
{
    public interface ICreateIBankAccountService
    {
        Task<APIActionResult<CreateAccountResponse>> DoActionAsync(CreateAccountRequest request);
    }

    public class CreateIBankAccountService : ICreateIBankAccountService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public CreateIBankAccountService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<CreateAccountResponse>> DoActionAsync(CreateAccountRequest request)
        {
            string apiPath = APIConstant.EndPoint.Account.Create;

            HttpResponseMessage httpResponseMessage = await _iBankOpenAPIClient.PostAsJsonAsync(apiPath, request);

            return await httpResponseMessage.AsActionResultAsync<CreateAccountResponse>();
        }
    }
}
