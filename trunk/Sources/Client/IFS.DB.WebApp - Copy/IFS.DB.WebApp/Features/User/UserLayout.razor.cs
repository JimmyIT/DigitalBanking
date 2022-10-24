using IFS.DB.WebApp.Helpers.Constants;

namespace IFS.DB.WebApp.Features.User;

public partial class UserLayout
{
    // protected override async Task OnInitializedAsync()
    // {
    //     var authState = await _authStateProvider.GetAuthenticationStateAsync();
    //     if (authState.User.Identity.IsAuthenticated)
    //     {
    //         if (!authState.User.IsInRole(UserRoles.Customer))
    //         {
    //             await _localStorageSvc.ClearAsync();
    //             _navigateManager.NavigateTo("/");
    //         }
    //     }
    //     else
    //     {
    //         await _localStorageSvc.ClearAsync();
    //         _navigateManager.NavigateTo("/");
    //     }
    // }
}
