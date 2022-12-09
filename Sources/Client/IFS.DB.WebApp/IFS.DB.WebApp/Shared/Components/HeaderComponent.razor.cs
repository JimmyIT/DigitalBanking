using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;

namespace IFS.DB.WebApp.Shared.Components;

public partial class HeaderComponent
{
    [CascadingParameter] IModalService HeaderComponentModalSvc { get; set; } = default!;

    private UserInfoModel _AuthorisedUser = FakeData.AuthorisedUser;
    private NotificationComponent _notificationComponent;
    private LiveChatComponent _liveChatComponent;
    private bool _isActiveNotification = false;
    private bool _isActiveLiveChat = false;
    private bool _isActiveProfileSubmenu = false;
    private bool _isActivePaymentSubmenu = false;
    private bool _isActiveOtherSubmenu = false;
    private string _styleDisplayPaymentSubmenu = "display: none;";
    private string _styleDisplayOtherSubmenu = "display: none;";
    private string _styleDisplayProfileSubmenu = "display: none;"; 
    private string _styleDisplayLiveChatSubmenu = "display: none;"; 
    

    private async Task SignOut()
    {
        var parameters = new ModalParameters()
            .Add(nameof(CommonModalComponent.HeaderLabel), "Are you sure you want to log out?")
            .Add(nameof(CommonModalComponent.UseButtonOk), true)
            .Add(nameof(CommonModalComponent.UseButtonCancel), true)
            .Add(nameof(CommonModalComponent.ButtonOkText), "Yes")
            .Add(nameof(CommonModalComponent.ButtonCancelText), "No")
            .Add(nameof(CommonModalComponent.EventOkClick), EventCallback.Factory.Create(this, ConfirmedSignOut)); ;
        var options = new ModalOptions()
        {
            UseCustomLayout = true
        };
        HeaderComponentModalSvc.Show<CommonModalComponent>("Confirm Signout", parameters, options);
    }

    private async Task ConfirmedSignOut()
    {
        await _localStorageSvc.ClearAsync();
        _navigateManager.NavigateTo("/", forceLoad: true);
    }

    protected override void OnInitialized() => _navigateManager.LocationChanged += (s, e) => StateHasChanged();

    private bool IsActive(string href, NavLinkMatch navLinkMatch = NavLinkMatch.Prefix)
    {
        var relativePath = _navigateManager.ToBaseRelativePath(_navigateManager.Uri).ToLower();
        return navLinkMatch == NavLinkMatch.All ? $"/{relativePath}" == href.ToLower() : relativePath.StartsWith(href.ToLower());
    }

    private string GetActive(string href, NavLinkMatch navLinkMatch = NavLinkMatch.Prefix)
        => IsActive(href, navLinkMatch) ? "main-header-menu__item--active" : "";

    public async Task OnPaymentSubmenu_Click()
    {
        _isActivePaymentSubmenu = !_isActivePaymentSubmenu;
        await OnPaymentSubmenuStateChange(_isActivePaymentSubmenu);
    }

    public async Task OnPaymentSubmenuStateChange(bool isActivePaymentSubmenu)
    {
        if (isActivePaymentSubmenu)
        {
            _isActivePaymentSubmenu = isActivePaymentSubmenu;
            _styleDisplayPaymentSubmenu = "display: block;";
        }
        else
        {
            _styleDisplayPaymentSubmenu = "display: none;";
        }
        StateHasChanged();
    }

    public async Task OnOtherSubmenu_Click()
    {
        _isActiveOtherSubmenu = !_isActiveOtherSubmenu;
        await OnOtherSubmenuStateChange(_isActiveOtherSubmenu);
    }

    public async Task OnOtherSubmenuStateChange(bool isActiveOtherSubmenu)
    {
        if (isActiveOtherSubmenu)
        {
            _isActiveOtherSubmenu = isActiveOtherSubmenu;
            _styleDisplayOtherSubmenu = "display: block;";
        }
        else
        {
            _styleDisplayOtherSubmenu = "display: none;";
        }
        StateHasChanged();
    }

    private async Task OnNotification_Click()
    {
        _isActiveNotification = !_isActiveNotification;
        await OnNotificationStateChange(_isActiveNotification);
    }

    private async Task OnNotificationStateChange(bool isActiveNotification)
    {
        // Keep state on global variable in case mouse over/ mouse out 
        _isActiveNotification = isActiveNotification ? true : false;
        await _notificationComponent.SetActiveNotification(isActiveNotification);
    }

    private async Task OnLiveChatSubmenu_Click()
    {
        _isActiveLiveChat = !_isActiveLiveChat;
        await OnLiveChatSubmenuStateChange(_isActiveLiveChat);
    }

    private async Task OnLiveChatSubmenuStateChange(bool isActiveLiveChat)
    {
        if (isActiveLiveChat)
        {
            _isActiveLiveChat = isActiveLiveChat;
            _styleDisplayLiveChatSubmenu = "display: block;";
        }
        else
        {
            _styleDisplayLiveChatSubmenu = "display: none;";
        }
    }

    private async Task OpenLiveChatBox()
    {
        await _liveChatComponent.SetActiveLiveChat(true);
    }

    private async Task OnProfileSubmenu_Click()
    {
        _isActiveProfileSubmenu = !_isActiveProfileSubmenu;
        await OnProfileSubmenuStateChange(_isActiveProfileSubmenu);
    }

    private async Task OnProfileSubmenuStateChange(bool isActiveProfileSubmenu)
    {
        if (isActiveProfileSubmenu)
        {
            _isActiveProfileSubmenu = isActiveProfileSubmenu;
            _styleDisplayProfileSubmenu = "display: block;";
        }
        else
        {
            _styleDisplayProfileSubmenu = "display: none;";
        }
        StateHasChanged();
    }
}
