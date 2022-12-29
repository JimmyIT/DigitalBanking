using Microsoft.AspNetCore.Components.Routing;

namespace IFS.DB.WebApp.Shared.BaseComponents.Menu;

/// <summary>
/// Reference: https://github.com/Blazored/Menu
/// </summary>
public class MenuItem
{
    public int Position { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
    public List<string> BreadcrumbLinks { get; set; }
    public NavLinkMatch Match { get; set; }
    public MenuBuilder MenuItems { get; set; }
    public bool IsSubMenu { get; set; }
    public bool IsVisible { get; set; }
    public bool IsEnabled { get; set; }
    public string Icon { get; set; }
    public string IconCssToOpen { get; set; }
    public string IconCssToClose { get; set; }
}
