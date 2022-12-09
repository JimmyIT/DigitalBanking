using IFS.DB.OpenAPI.Client.AccountApplication.GetById;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.AccountApplication
{
    public interface IGetAccountApplicationByIdService
    {
        Task<APIActionResult<GetAccountApplicationByIdResponse>> DoActionAsync(string id);
    }

    public class GetAccountApplicationByIdService : IGetAccountApplicationByIdService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public GetAccountApplicationByIdService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<GetAccountApplicationByIdResponse>> DoActionAsync(string id)
        {
            string apiPath = APIConstant.EndPoint.AccountApplication.GetById.Replace(@"{id}", id);

            HttpResponseMessage responseMsg = await _iBankOpenAPIClient.GetAsync(apiPath);

            return await responseMsg.AsActionResultAsync<GetAccountApplicationByIdResponse>();
        }
    }
}
