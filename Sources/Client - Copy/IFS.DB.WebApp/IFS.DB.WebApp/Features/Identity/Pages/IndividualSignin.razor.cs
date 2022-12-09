using IFS.DB.OpenAPI.Client.Customers.IdentifySSE;
using IFS.DB.WebApp.Helpers.Constants;
using Microsoft.AspNetCore.Components.Authorization;

namespace IFS.DB.WebApp.Features.Identity.Pages;

public partial class IndividualSignin
{
    private SigninStepsEnum _currentSignInStep = SigninStepsEnum.FirstStep;
    private IdentifySSECustomerResponse? _sseCustomerIdentify;

    public enum SigninStepsEnum
    {
        FirstStep = 0,
        SecondStep = 1,
    }

    protected override async Task OnInitializedAsync()
    {
        AuthenticationState authState = await _authStateProvider.GetAuthenticationStateAsync();
        PageNavigator(authState);

        //var result = await _mediator.Send(new CheckAllowLoginCommand());
        //if (result.IsFailed)
        //{
        //    _navigateManager.NavigateTo("/not-existed-page");
        //}
    }

    private void ValidationOnValueChange(SigninStepsEnum signinStepsEnum)
    {
        _currentSignInStep = signinStepsEnum;
    }

    private void SetSseCustomerValue(IdentifySSECustomerResponse value)
    {
        _sseCustomerIdentify = value;
    }

    private void PageNavigator(AuthenticationState authState)
    {
        if (authState.User.Identity.IsAuthenticated)
        {
            if (authState.User.IsInRole(UserRoles.SSECustomer))
            {
                _navigateManager.NavigateTo("/user/dashboard", forceLoad: true);
                return;
            }

            if (authState.User.IsInRole(UserRoles.MSECustomer))
            {
                _navigateManager.NavigateTo("/admin/dashboard", forceLoad: true);
                return;
            }
        }
    }
}
