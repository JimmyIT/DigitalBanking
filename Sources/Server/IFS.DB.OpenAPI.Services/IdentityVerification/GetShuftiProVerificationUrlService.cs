using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Documents.GetShuftiProVerificationURL;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.IdentityVerification
{
    public interface IGetShuftiProVerificationUrlService
    {
        Task<APIActionResult<GetShuftiProVerificationURLResponse>> DoActionAsync(GetShuftiProVerificationURLRequest objectRequest);
    }

    public class GetShuftiProVerificationUrlService : BaseAPIService, IGetShuftiProVerificationUrlService
    {
        public GetShuftiProVerificationUrlService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        { }

        public async Task<APIActionResult<GetShuftiProVerificationURLResponse>> DoActionAsync(GetShuftiProVerificationURLRequest objectRequest)
        {
            string apiPath = APIConstant.EndPoint.Document.GetShuftiProVerificationURL;
            HttpResponseMessage resultResponse = await _DigitalBankingOpenAPIClient.PostAsJsonAsync(apiPath, objectRequest);
            return await resultResponse.AsActionResultAsync<GetShuftiProVerificationURLResponse>();
        }
    }
}
