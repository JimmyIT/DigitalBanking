using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;

namespace IFS.DB.WebApp.Shared.BaseComponents.Menu;

public partial class SubMenuComponent : ComponentBase
{
    private ElementReference _submenuContainer;
    private ElementReference _buttonSubmenu;
    private ElementReference _linkMenusContainer;
    private bool _keepActive = false;
    private bool _isActive = false;
    protected override void OnParametersSet()
    {
        base.OnParametersSet();        
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (_isActive)
        {
            await _linkMenusContainer.FocusAsync();
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    protected string CssString
    {
        get
        {
            var cssString = "blazored-sub-menu-header";

            cssString += $" {CssClass}";

            return cssString.Trim();
        }
    }

    protected async Task ToggleSubMenu(bool isActive)
    {
        await SubmenuStateHasChangeAsync(isActive);
    }

    internal async Task SubmenuStateHasChangeAsync(bool isActive)
    {
        _isActive = isActive;
        if(_isActive)
        {
            _keepActive = false;
        }
        else
        {
            await OutFocusAsync();
        }
    }

    private async Task OutFocusAsync()
    {
        if (_keepActive)
            return;

        _isActive = false;
        await Task.Delay(200);
        StateHasChanged();
    }

    private async Task KeepStateWhenClickItemAsync(bool isKeep)
    {
        _isActive = isKeep;
        _keepActive = isKeep;
        if (isKeep)
        {
            await _submenuContainer.FocusAsync();
        }
        else
        {
            await OutFocusAsync();
        }
    }

    private string GetActive()
        => IsActive() ? "main-header-submenu__item--active" : "";

    private bool IsActive()
    {
        var relativePath = _navigateManager.ToBaseRelativePath(_navigateManager.Uri).ToLower();
        return MenuItems.Any(item => item.Match == NavLinkMatch.All ? $"/{relativePath}" == item.Link.ToLower() : relativePath.StartsWith(item.Link.ToLower())); ;
    }

    /// <summary>
    /// Handler for the key down events
    /// </summary>
    /// <param name="eventArgs">keyboard event</param>
    protected void KeyDownHandler(KeyboardEventArgs eventArgs)
    {
        if (eventArgs.Key == "Enter" || eventArgs.Key == " " || eventArgs.Key == "Spacebar")
        {
            //ToggleSubMenu();
        }
    }

    #region Properties

    [Parameter] public string Header { get; set; }
    [Parameter] public string CssClass { get; set; }
    [Parameter] public bool IsEnabled { get; set; } = true;
    [Parameter] public IEnumerable<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    #endregion
}
