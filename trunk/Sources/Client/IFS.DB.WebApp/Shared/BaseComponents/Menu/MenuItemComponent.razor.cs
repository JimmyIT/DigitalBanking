using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace IFS.DB.WebApp.Shared.BaseComponents.Menu;

public partial class MenuItemComponent : ComponentBase
{
    private bool _isSubMenu => SubMenuComponent != null;
    protected string CssString
    {
        get
        {
            var cssString = string.Empty;

            cssString += $"{CssClass}";

            return cssString.Trim();
        }
    }

    private string GetActive()
        => IsActive() ? "main-header-menu__item--active" : "";

    private bool IsActive()
    {
        var relativePath = _navigateManager.ToBaseRelativePath(_navigateManager.Uri).ToLower();
        if(MenuItem.BreadcrumbLinks?.Count > 0)
        {            
            return MenuItem.BreadcrumbLinks.Any(breadCrumbLink => $"/{relativePath}".Contains(breadCrumbLink.ToLower())); 
        }
        else
        { 
            return MenuItem.Match == NavLinkMatch.All ? $"/{relativePath}" == MenuItem.Link.ToLower() : relativePath.StartsWith(MenuItem.Link.ToLower());
        }
    }

    private async Task ToggleSubMenuItem()
    {
        if(await IsMobileAsync())
        {
            _navigateManager.NavigateTo(MenuItem.Link, true);
        }
        else
        {
            _navigateManager.NavigateTo(MenuItem.Link);
            await SubMenuComponent.SubmenuStateHasChangeAsync(false);
        }
    }

    private async Task ToggleMenuItem()
    {
        _navigateManager.NavigateTo(MenuItem.Link, await IsMobileAsync());
    }

    public async Task<bool> IsMobileAsync()
    {
        return await _jsRuntime.InvokeAsync<bool>("mobileAndTabletCheck", new object[] { });
        
    }

    #region Properties

    [CascadingParameter(Name = "MenuComponent")] public MenuComponent MenuComponent { get; set; }
    [CascadingParameter(Name = "SubMenuComponent")] public SubMenuComponent SubMenuComponent { get; set; }
    [Parameter] public string CssClass { get; set; } = string.Empty;
    [Parameter] public string SubText { get; set; } = string.Empty;
    [Parameter] public MenuItem MenuItem { get; set; }

    #endregion
}
