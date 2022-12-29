using FluentResults;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Customers.SignInSSE;
using IFS.DB.WebApp.Helpers.Constants;
using IFS.DB.WebApp.Helpers.Extensions;
using MediatR;

namespace IFS.DB.WebApp.Services.Apis.Customers;

public class SseCustomerSignInCommand : SignInSSECustomerRequest, IRequest<Result<SignInSSECustomerResponse>>
{
}

public class SseCustomerSignInHandler : IRequestHandler<SseCustomerSignInCommand, Result<SignInSSECustomerResponse>>
{
    private readonly HttpClient _client;

    public SseCustomerSignInHandler(IHttpClientFactory clientFactory)
        => _client = clientFactory.CreateClient(AppConstant.DigitalBankClientName);

    public Task<Result<SignInSSECustomerResponse>> Handle(SseCustomerSignInCommand request,
        CancellationToken cancellationToken = default)
        => _client.PostAsJsonAsync(APIConstant.EndPoint.Customer.SignInSSE, request, cancellationToken)
            .AsResultAsync<SignInSSECustomerResponse>();
}