using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Documents.UploadAML;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Documents
{
    public interface IUploadAMLDocumentService
    {
        Task<APIActionResult<UploadAMLDocumentResponse>> DoActionAsync(UploadAMLDocumentRequest request);
    }

    public class UploadAMLDocumentService : IUploadAMLDocumentService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public UploadAMLDocumentService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<UploadAMLDocumentResponse>> DoActionAsync(UploadAMLDocumentRequest request)
        {
            string url = APIConstant.EndPoint.Document.UploadAML;

            HttpResponseMessage httpResponseMsg = await _iBankOpenAPIClient.PostAsJsonAsync(url, request);

            return await httpResponseMsg.AsActionResultAsync<UploadAMLDocumentResponse>();
        }
    }
}
