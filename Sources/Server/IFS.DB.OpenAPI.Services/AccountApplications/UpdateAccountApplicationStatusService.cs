using IFS.DB.OpenAPI.Client.AccountApplication.UpdateStatus;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.AccountApplication
{
    public interface IUpdateAccountApplicationStatusService
    {
        Task<APIActionResult<UpdateAccountApplicationStatusResponse>> DoActionAsync(UpdateAccountApplicationStatusRequest request);
    }

    public class UpdateAccountApplicationStatusService : IUpdateAccountApplicationStatusService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public UpdateAccountApplicationStatusService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<UpdateAccountApplicationStatusResponse>> DoActionAsync(UpdateAccountApplicationStatusRequest request)
        {
            string apiPath = APIConstant.EndPoint.AccountApplication.UpdateStatus;

            HttpResponseMessage httpResponseMessage = await _iBankOpenAPIClient.PutAsJsonAsync(apiPath, request);

            return await httpResponseMessage.AsActionResultAsync<UpdateAccountApplicationStatusResponse>();
        }
    }
}
