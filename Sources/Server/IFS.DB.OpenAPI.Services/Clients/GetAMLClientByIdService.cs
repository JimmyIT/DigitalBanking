using IFS.DB.OpenAPI.Client.Clients.GetAMLById;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Clients
{
    public interface IGetAMLClientByIdService
    {
        Task<APIActionResult<GetAMLClientByIdResponse>> DoActionAsync(string id);
    }

    public class GetAMLClientByIdService : IGetAMLClientByIdService
    {

        private readonly HttpClient _iBankOpenAPIClient;

        public GetAMLClientByIdService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<GetAMLClientByIdResponse>> DoActionAsync(string id)
        {
            string apiPath = APIConstant.EndPoint.Client.GetAMLById.Replace(@"{id}", id);

            HttpResponseMessage httpResponseMessage = await _iBankOpenAPIClient.GetAsync(apiPath);

            return await httpResponseMessage.AsActionResultAsync<GetAMLClientByIdResponse>();
        }
    }
}
