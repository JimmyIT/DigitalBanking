namespace IFS.DB.WebApp.Helpers.MessageHandler;

public class AddIdempotencyKeyHeaderMessageHandler : DelegatingHandler
{
    private const string XIdempotencyKey = "x-idempotency-key";

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (request.Method != HttpMethod.Get)
        {
            request.Headers.Add(XIdempotencyKey, Guid.NewGuid().ToString());
        }

        return base.SendAsync(request, cancellationToken);
    }
}