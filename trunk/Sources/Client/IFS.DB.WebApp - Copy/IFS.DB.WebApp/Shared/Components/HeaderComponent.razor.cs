namespace IFS.DB.WebApp.Shared.Components;

public partial class HeaderComponent
{
    private async Task SignOut()
    {
        await _localStorageSvc.ClearAsync();
        _navigateManager.NavigateTo("/", forceLoad: true);
    }
}
