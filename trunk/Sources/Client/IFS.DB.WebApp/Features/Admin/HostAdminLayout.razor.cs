using IFS.DB.WebApp.Helpers.Constants;

namespace IFS.DB.WebApp.Features.Admin;

/// <summary>/// 
/// Admin features will use this layout
/// </summary>
public partial class HostAdminLayout
{

    protected override async Task OnInitializedAsync()
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        if (authState.User.Identity.IsAuthenticated)
        {
            if (!authState.User.IsInRole(UserRoles.Host))
            {
                await _localStorageSvc.ClearAsync();
                _navigateManager.NavigateTo("/");
            }
        }
        else
        {
            await _localStorageSvc.ClearAsync();
            _navigateManager.NavigateTo("/");
        }
    }
}
