using IFS.DB.WebApp.Helpers.Constants;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Features.Identity.Pages;

public partial class IndividualSignin
{
    private EditContext _editContext;
    private UserSignIn _userSignInModel = new();

    protected override async Task OnInitializedAsync()
    {
        AuthenticationState authState = await _authStateProvider.GetAuthenticationStateAsync();
        PageNavigator(authState);

        _editContext = new EditContext(_userSignInModel);
        _editContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
    }

    private async Task SignIn()
    {
        if (_editContext.Validate())
        {
            if (_userSignInModel.CustomerID.ToLower().Contains("customer"))
            {
                _userSignInModel.Role = UserRoles.Customer;
                await _localStorageSvc.SetItemAsync<UserSignIn>("Identity", _userSignInModel);
            }
            else if (_userSignInModel.CustomerID.ToLower().Contains("admin"))
            {
                _userSignInModel.Role = UserRoles.Admin;
                await _localStorageSvc.SetItemAsync<UserSignIn>("Identity", _userSignInModel);
            }

            AuthenticationState authState = await _authStateProvider.GetAuthenticationStateAsync();
            PageNavigator(authState);
        }
    }

    private void PageNavigator(AuthenticationState authState)
    {
        if (authState.User.Identity.IsAuthenticated)
        {
            if (authState.User.IsInRole(UserRoles.Customer))
            {
                _navigateManager.NavigateTo("/user/dashboard", forceLoad: true);
                return;
            }

            if (authState.User.IsInRole(UserRoles.Admin))
            {
                _navigateManager.NavigateTo("/admin/dashboard", forceLoad: true);
                return;
            }
        }
    }
}
