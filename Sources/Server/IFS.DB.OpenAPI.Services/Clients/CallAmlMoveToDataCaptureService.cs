using IFS.DB.OpenAPI.Client.Clients.MoveAMLToDataCapture;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Services.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Clients
{
    public interface ICallAmlMoveToDataCaptureService
    {
        Task<APIActionResult<MoveAMLClientToDataCaptureResponse>> DoActionAsync(MoveAMLClientToDataCaptureRequest request);
    }

    public class CallAmlMoveToDataCaptureService : ICallAmlMoveToDataCaptureService
    {
        private readonly HttpClient _iBankOpenAPIClient;

        public CallAmlMoveToDataCaptureService(IHttpClientFactory httpClientFactory)
        {
            _iBankOpenAPIClient = httpClientFactory.CreateClient(Constants.IBANK_CLIENT);
        }

        public async Task<APIActionResult<MoveAMLClientToDataCaptureResponse>> DoActionAsync(MoveAMLClientToDataCaptureRequest request)
        {
            string apiPath = APIConstant.EndPoint.Client.MoveAMLToDataCapture;

            HttpResponseMessage httpResponseMsg = await _iBankOpenAPIClient.PostAsJsonAsync(apiPath, request);

            return await httpResponseMsg.AsActionResultAsync<MoveAMLClientToDataCaptureResponse>();
        }
    }
}
