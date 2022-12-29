using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace IFS.DB.WebApp.Shared.Components;

public partial class HeaderComponent
{
    [CascadingParameter] IModalService HeaderComponentModalSvc { get; set; } = default!;
        
    private bool _isDeviceMode = false;
    private bool _isActiveBurgerMenu = false;

    private string _styleToShowMenuWhenClickBurgerButton = "display: none;";

    private MainHeaderNavComponent _mainHeaderNavComponent;
    internal LiveChatComponent _liveChatComponent;

    private ElementReference _divMenuBurgerButtonsRef;
    private ElementReference _divMenuContainerRef;
    private ElementReference _divMenuItemsContainerRef;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {        
        if(_isActiveBurgerMenu)
        {
            await _divMenuContainerRef.FocusAsync();
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    protected override async void OnInitialized() 
    { 
        _navigateManager.LocationChanged += (s, e) => StateHasChanged();
        await IsMobileAsync();
    }
        
    public async Task IsMobileAsync()
    {
        _isDeviceMode = await _jsRuntime.InvokeAsync<bool>("mobileAndTabletCheck", new object[] { });
        StateHasChanged();
    }

    private async Task BurgerMenu_OnclickAsync(bool isActive)
    {
        _isActiveBurgerMenu = isActive;
        if (_isActiveBurgerMenu)
        {
            await _divMenuContainerRef.FocusAsync();
            _styleToShowMenuWhenClickBurgerButton = "display:block;";
        }
        else
        {
            _styleToShowMenuWhenClickBurgerButton = "display:none;";
            StateHasChanged();
        }
    }

    internal async Task BurgerMenu_OnFocusOutAsync()
        => await BurgerMenu_OnclickAsync(false);    
}
