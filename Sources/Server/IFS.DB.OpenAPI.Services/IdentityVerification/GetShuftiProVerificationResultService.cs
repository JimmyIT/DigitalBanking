using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Documents.GetShuftiProVerificationStatus;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.IdentityVerification
{
    public interface IGetShuftiProVerificationResultService
    {
        Task<APIActionResult<GetShuftiProVerificationStatusResponse>> DoActionAsync(string shuftiProRefernce);
    }

    public class GetShuftiProVerificationResultService : BaseAPIService, IGetShuftiProVerificationResultService
    {
        public GetShuftiProVerificationResultService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        { }

        public async Task<APIActionResult<GetShuftiProVerificationStatusResponse>> DoActionAsync(string shuftiProRefernce)
        {
            string apiPath = $"{APIConstant.EndPoint.Document.GetShuftiProVerificationStatus}?reference={shuftiProRefernce}";
            HttpResponseMessage resultResponse = await _DigitalBankingOpenAPIClient.GetAsync(apiPath);
            return await resultResponse.AsActionResultAsync<GetShuftiProVerificationStatusResponse>();
        }
    }
}
