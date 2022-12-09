using FluentResults;
using IFS.DB.OpenAPI.Client.Constants;
using IFS.DB.OpenAPI.Client.Customers.IdentifySSE;
using IFS.DB.WebApp.Helpers.Constants;
using IFS.DB.WebApp.Helpers.Extensions;
using MediatR;

namespace IFS.DB.WebApp.Services.Apis.Customers;

public class IdentifySseCustomerCommand : IdentifySSECustomerRequest, IRequest<Result<IdentifySSECustomerResponse>>
{
}

public class
    IdentifySseCustomerHandler : IRequestHandler<IdentifySseCustomerCommand, Result<IdentifySSECustomerResponse>>
{
    private readonly HttpClient _client;

    public IdentifySseCustomerHandler(IHttpClientFactory clientFactory)
        => _client = clientFactory.CreateClient(AppConstant.DigitalBankClientName);

    public Task<Result<IdentifySSECustomerResponse>> Handle(
        IdentifySseCustomerCommand request,
        CancellationToken cancellationToken
    ) => _client.PostAsJsonAsync(APIConstant.EndPoint.Customer.IdentifySSE, request, cancellationToken)
        .AsResultAsync<IdentifySSECustomerResponse>();
}