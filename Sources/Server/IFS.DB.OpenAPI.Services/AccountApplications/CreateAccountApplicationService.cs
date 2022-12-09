using IFS.DB.OpenAPI.Client.AccountApplication.Create;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.AccountApplication
{

    public interface ICreateAccountApplicationService
    {
        Task<APIActionResult<CreateAccountApplicationResponse>> DoActionAsync(CreateAccountApplicationRequest request);
    }

    public class CreateAccountApplicationService : ICreateAccountApplicationService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public CreateAccountApplicationService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<CreateAccountApplicationResponse>> DoActionAsync(CreateAccountApplicationRequest request)
        {
            string apiPath = APIConstant.EndPoint.AccountApplication.Create;

            HttpResponseMessage httpResponseMsg = await _iBankOpenAPIClient.PostAsJsonAsync(apiPath, request);

            return await httpResponseMsg.AsActionResultAsync<CreateAccountApplicationResponse>();
        }
    }
}
