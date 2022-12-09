using IFS.DB.OpenAPI.Services.Base;
using System.Net.Http;

namespace IFS.DB.OpenAPI.Services.Clients
{
    public interface IRejectTagService
    {
    }

    public class RejectTagService : BaseAPIService, IRejectTagService
    {
        public RejectTagService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
