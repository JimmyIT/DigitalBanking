using IFS.DB.OpenAPI.Client.Clients.CreateAML;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Clients
{
    public interface ICreateAMLClientService
    {
        Task<APIActionResult<CreateAMLClientResponse>> DoActionAsync(CreateAMLClientRequest request);
    }

    public class CreateAMLClientService : ICreateAMLClientService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public CreateAMLClientService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<CreateAMLClientResponse>> DoActionAsync(CreateAMLClientRequest request)
        {
            string apiPath = APIConstant.EndPoint.Client.CreateAML;

            HttpResponseMessage httpResponseMsg = await _iBankOpenAPIClient.PostAsJsonAsync(apiPath, request);

            return await httpResponseMsg.AsActionResultAsync<CreateAMLClientResponse>();
        }
    }
}
