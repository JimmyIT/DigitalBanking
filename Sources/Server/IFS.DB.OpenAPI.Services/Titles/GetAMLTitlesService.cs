using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Titles.GetAML;
using IFS.DB.OpenAPI.Services.Base;
using IFS.DB.OpenAPI.Services.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Titles
{
    public interface IGetAMLTitlesService
    {
        Task<APIActionResult<IEnumerable<GetAMLTitlesResponse>>> DoActionAsync();
    }

    public class GetAMLTitlesService : BaseAPIService, IGetAMLTitlesService
    {
        public GetAMLTitlesService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        { }

        public async Task<APIActionResult<IEnumerable<GetAMLTitlesResponse>>> DoActionAsync()
        {
            string apiPath = APIConstant.EndPoint.Title.GetAML;
            HttpResponseMessage httpResponseMsg = await _DigitalBankingOpenAPIClient.GetAsync(apiPath);
            return await httpResponseMsg.AsActionResultAsync<IEnumerable<GetAMLTitlesResponse>>();
        }
    }
}
