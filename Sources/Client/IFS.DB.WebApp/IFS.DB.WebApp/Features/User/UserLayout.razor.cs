using IFS.DB.WebApp.Helpers.Constants;
using Microsoft.AspNetCore.Components.Authorization;

namespace IFS.DB.WebApp.Features.User;

public partial class UserLayout
{
    protected override async Task OnInitializedAsync()
    {
        AuthenticationState authState = await _authStateProvider.GetAuthenticationStateAsync();
        if (!authState.User.Identity.IsAuthenticated)
        {
            await _localStorageSvc.ClearAsync();
            _navigateManager.NavigateTo("/");
        }
    }
}
