using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Messages.GetByStatusAndDirection;
using IFS.DB.OpenAPI.Services.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.MQMessages
{
    public interface IGetMessageByStatusAndDirectionService
    {
        Task<APIActionResult<List<GetMessageByStatusAndDirectionResponse>>> DoActionAsync(int status, string direction);
    }

    public class GetMessageByStatusAndDirectionService : IGetMessageByStatusAndDirectionService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public GetMessageByStatusAndDirectionService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<List<GetMessageByStatusAndDirectionResponse>>> DoActionAsync(int status, string direction)
        {
            string apiPath = APIConstant.EndPoint.Message.GetByStatusAndDirection
                    .Replace(@"{status}", status.ToString())
                    .Replace(@"{direction}", direction);

            HttpResponseMessage httpResponseMessage = await _iBankOpenAPIClient.GetAsync(apiPath);

            return await httpResponseMessage.AsActionResultAsync<List<GetMessageByStatusAndDirectionResponse>>();
        }
    }
}
