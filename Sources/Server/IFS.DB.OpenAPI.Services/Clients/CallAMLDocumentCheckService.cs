using IFS.DB.OpenAPI.Client.Clients.CheckMissingDocument;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Clients
{
    public interface ICallAMLDocumentCheckService
    {
        Task<APIActionResult<CheckClientMissingDocumentResponse>> DoActionAsync(CheckClientMissingDocumentRequest request);
    }

    public class CallAMLDocumentCheckService : BaseAPIService, ICallAMLDocumentCheckService
    {
        public CallAMLDocumentCheckService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        public async Task<APIActionResult<CheckClientMissingDocumentResponse>> DoActionAsync(CheckClientMissingDocumentRequest request)
        {
            string apiPath = APIConstant.EndPoint.Client.CheckMissingDocument;

            HttpResponseMessage httpResonseMsg = await _DigitalBankingOpenAPIClient.PostAsJsonAsync(apiPath, request);

            return await httpResonseMsg.AsActionResultAsync<CheckClientMissingDocumentResponse>();
        }
    }
}
