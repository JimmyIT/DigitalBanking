using IFS.DB.OpenAPI.Client.Clients.CreateOnBoarding;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Clients
{
    public interface ICreateIBankClientService
    {
        Task<APIActionResult<CreateOnBoardingClientResponse>> DoActionAsync(CreateOnBoardingClientRequest request);
    }

    public class CreateIBankClientService : ICreateIBankClientService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public CreateIBankClientService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<CreateOnBoardingClientResponse>> DoActionAsync(CreateOnBoardingClientRequest request)
        {
            string apiPath = APIConstant.EndPoint.Client.CreateOnBoarding;

            HttpResponseMessage httpResponseMessage = await _iBankOpenAPIClient.PostAsJsonAsync(apiPath, request);

            return await httpResponseMessage.AsActionResultAsync<CreateOnBoardingClientResponse>();
        }
    }
}
