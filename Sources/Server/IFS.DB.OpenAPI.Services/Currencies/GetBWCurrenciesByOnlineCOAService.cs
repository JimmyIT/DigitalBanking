using IFS.DB.OpenAPI.Client.ChartOfAccounts.GetCurrenciesByOnlineCOA;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Currencies
{
    public interface IGetBWCurrenciesByOnlineCOAService
    {
        Task<APIActionResult<IEnumerable<GetCurrenciesByOnlineCOAResponse>>> DoActionAsync(int chartOfAccountId);
    }

    public class GetBWCurrenciesByOnlineCOAService : BaseAPIService, IGetBWCurrenciesByOnlineCOAService
    {
        public GetBWCurrenciesByOnlineCOAService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        { }

        public async Task<APIActionResult<IEnumerable<GetCurrenciesByOnlineCOAResponse>>> DoActionAsync(int chartOfAccountId)
        {
            string apiPath = APIConstant.EndPoint.ChartOfAccount.GetCurrenciesByOnlineCOA
                .Replace(@"{chartOfAccountId}", chartOfAccountId.ToString());
            HttpResponseMessage httpResponseMsg = await _DigitalBankingOpenAPIClient.GetAsync(apiPath);
            return await httpResponseMsg.AsActionResultAsync<IEnumerable<GetCurrenciesByOnlineCOAResponse>>();
        }
    }
}
