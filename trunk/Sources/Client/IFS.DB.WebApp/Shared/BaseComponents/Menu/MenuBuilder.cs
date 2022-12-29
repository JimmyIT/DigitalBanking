using Microsoft.AspNetCore.Components.Routing;

namespace IFS.DB.WebApp.Shared.BaseComponents.Menu;

/// <summary>
/// Reference: https://github.com/Blazored/Menu
/// </summary>
public class MenuBuilder
{
    private List<MenuItem> _menuItems;

    private string CssToClose;
    private string CssToOpen;

    public MenuBuilder()
    {
        _menuItems = new List<MenuItem>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderBy"></param>
    /// <returns></returns>
    internal List<MenuItem> Build(Func<MenuItem, int> orderBy)
    {
        var menuItems = _menuItems.OrderBy(orderBy).ToList();
        menuItems.ForEach(m =>
        {
            m.IconCssToClose = CssToClose;
            m.IconCssToOpen = CssToOpen;
        });
        return menuItems.ToList();
    }

    /// <summary>
    /// add icon css to close
    /// </summary>
    /// <param name="closeCss"></param>
    /// <returns></returns>
    public MenuBuilder AddIconCssToClose(string closeCss)
    {
        CssToClose = closeCss;
        return this;
    }

    /// <summary>
    /// add icon css to open
    /// </summary>
    /// <param name="openCss"></param>
    /// <returns></returns>
    public MenuBuilder AddIconCssToOpen(string openCss)
    {
        CssToOpen = openCss;
        return this;
    }

    /// <summary>
    /// Add a menu item
    /// </summary>
    /// <param name="position"></param>
    /// <param name="title"></param>
    /// <param name="link"></param>
    /// <param name="match"></param>
    /// <param name="isVisible"></param>
    /// <param name="isEnabled"></param>
    /// <returns></returns>
    public MenuBuilder AddItem(int position, string title,
                               string link, NavLinkMatch match = NavLinkMatch.Prefix,
                               bool isVisible = true, bool isEnabled = true)
    {
        var menuItem = new MenuItem
        {
            Position = position,
            Title = title,
            Link = link,
            Match = match,
            IsSubMenu = false,
            IsVisible = isVisible,
            IsEnabled = isEnabled
        };

        _menuItems.Add(menuItem);

        return this;
    }

    /// <summary>
    /// add a sub menu
    /// </summary>
    /// <param name="position"></param>
    /// <param name="title"></param>
    /// <param name="menuItems"></param>
    /// <param name="isVisible"></param>
    /// <param name="isEnabled"></param>
    /// <returns></returns>
    public MenuBuilder AddSubMenu(int position, string title,
                                  MenuBuilder menuItems, bool isVisible = true,
                                  bool isEnabled = true)
    {
        var menuItem = new MenuItem();
        menuItem.Position = position;
        menuItem.IsSubMenu = true;
        menuItem.Title = title;
        menuItem.MenuItems = menuItems;
        menuItem.IsVisible = isVisible;
        menuItem.IsEnabled = isEnabled;
        menuItem.IconCssToClose = CssToClose;
        menuItem.IconCssToOpen = CssToOpen;

        _menuItems.Add(menuItem);
        return this;
    }    
}
