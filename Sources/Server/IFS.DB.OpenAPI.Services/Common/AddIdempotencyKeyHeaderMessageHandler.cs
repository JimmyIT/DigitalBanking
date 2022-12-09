using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Common
{
    public class AddIdempotencyKeyHeaderMessageHandler : DelegatingHandler
    {
        public const string x_idempotency_key = "x-idempotency-key";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method != HttpMethod.Get)
            {
                request.Headers.Add(x_idempotency_key, Guid.NewGuid().ToString());
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
