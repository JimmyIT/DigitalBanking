using IFS.DB.OpenAPI.Client.Accounts.UpdateBWInternetFlag;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Accounts
{
    public interface IUpdateBWAccountInternetFlagService
    {
        Task<APIActionResult<UpdateBWAccountInternetFlagResponse>> DoActionAsync(UpdateBWAccountInternetFlagRequest request);
    }

    public class UpdateBWAccountInternetFlagService : IUpdateBWAccountInternetFlagService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public UpdateBWAccountInternetFlagService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<UpdateBWAccountInternetFlagResponse>> DoActionAsync(UpdateBWAccountInternetFlagRequest request)
        {
            string apiPath = APIConstant.EndPoint.Account.UpdateBWInternetFlag;

            HttpResponseMessage httpResponseMessage = await _iBankOpenAPIClient.PutAsJsonAsync(apiPath, request);

            return await httpResponseMessage.AsActionResultAsync<UpdateBWAccountInternetFlagResponse>();
        }
    }
}
