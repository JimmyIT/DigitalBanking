using IFS.DB.WebApp.Helpers.Constants;
using IFS.DB.WebApp.Models.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using static IFS.DB.WebApp.Helpers.Enums.CorporateSignInEnum;

namespace IFS.DB.WebApp.Features.Identity.Pages;

public partial class CorporateSignin
{
    private SigninStepsEnum _currentSignInStep = SigninStepsEnum.FirstStep;
    private  UserSignInModel _userSignInModel = default!;
    private  MseAuth _mseAuth = default!;
    private  UserIdModel _userIdModel = default!;

    protected override async Task OnInitializedAsync()
    {
        _userSignInModel = new UserSignInModel();
        _mseAuth = new MseAuth();
        _userIdModel = new UserIdModel();
        
        AuthenticationState authState = await _authStateProvider.GetAuthenticationStateAsync();
        PageNavigator(authState);
    }

    private async Task ValidationOnValueChange(SigninStepsEnum signinStepsEnum)
    {
        _currentSignInStep = signinStepsEnum;
        StateHasChanged();
    }

    private void PageNavigator(AuthenticationState authState)
    {
        if (authState.User.Identity.IsAuthenticated)
        {
            if(authState.User.IsInRole(UserRoles.Host))
            {
                _navigateManager.NavigateTo("/customer-maintenance", forceLoad: true);
            }
            else if (authState.User.IsInRole(UserRoles.Admin))
            {
                _navigateManager.NavigateTo("/admin/dashboard", forceLoad: true);
            }
            else
            {
                _navigateManager.NavigateTo("/user/dashboard", forceLoad: true);
            }
        }
    }
}
