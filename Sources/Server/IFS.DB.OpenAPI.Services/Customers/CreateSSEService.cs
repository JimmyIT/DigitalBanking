using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Customers.CreateSSE;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Customers
{
    public interface ICreateSSEService
    {
        Task<APIActionResult<CreateSSECustomerResponse>> DoActionAsync(CreateSSECustomerRequest request);
    }

    public class CreateSSEService : ICreateSSEService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public CreateSSEService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(IBankAPIConfig.CLIENT_NAME);
        }

        public async Task<APIActionResult<CreateSSECustomerResponse>> DoActionAsync(CreateSSECustomerRequest request)
        {
            string apiPath = APIConstant.EndPoint.Customer.CreateSSE;
            HttpResponseMessage httpResponseMsg = await _iBankOpenAPIClient.PostAsJsonAsync(apiPath, request);
            return await httpResponseMsg.AsActionResultAsync<CreateSSECustomerResponse>();
        }
    }
}
