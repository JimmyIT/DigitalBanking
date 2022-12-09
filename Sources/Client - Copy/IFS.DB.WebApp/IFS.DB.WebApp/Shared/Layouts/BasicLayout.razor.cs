using Microsoft.AspNetCore.Components.Routing;

namespace IFS.DB.WebApp.Shared.Layouts;

public partial class BasicLayout
{
    protected override async Task OnInitializedAsync()
    {

    }

    private bool IsUseFooter(string href, NavLinkMatch navLinkMatch = NavLinkMatch.Prefix)
    {
        var relativePath = _navigateManager.ToBaseRelativePath(_navigateManager.Uri).ToLower();
        return navLinkMatch == NavLinkMatch.All ? $"/{relativePath}" == href.ToLower() : relativePath.StartsWith(href.ToLower());
    }
}
