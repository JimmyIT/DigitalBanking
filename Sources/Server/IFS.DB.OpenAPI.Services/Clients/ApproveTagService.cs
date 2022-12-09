using IFS.DB.OpenAPI.Services.Base;
using System.Net.Http;

namespace IFS.DB.OpenAPI.Services.Clients
{
    public interface IApproveTagService
    {
    }

    public class ApproveTagService : BaseAPIService, IApproveTagService
    {
        public ApproveTagService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
