using FluentResults;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.WebApp.Helpers.Constants;
using IFS.DB.WebApp.Helpers.Extensions;
using MediatR;

namespace IFS.DB.OpenAPI.Services.Systems;

public class CheckAllowLoginCommand : IRequest<Result<Unit>>
{
}

public class CheckAllowLoginHandler : IRequestHandler<CheckAllowLoginCommand, Result<Unit>>
{
    private readonly HttpClient _client;

    public CheckAllowLoginHandler(IHttpClientFactory httpClientFactory)
        => _client = httpClientFactory.CreateClient(AppConstant.DigitalBankClientName);

    public Task<Result<Unit>> Handle(CheckAllowLoginCommand request, CancellationToken cancellationToken = default)
    {
        return _client.PostAsJsonAsync(APIConstant.EndPoint.System.AllowLogon, new { }, cancellationToken)
            .AsResultAsync<Unit>();
    }
}