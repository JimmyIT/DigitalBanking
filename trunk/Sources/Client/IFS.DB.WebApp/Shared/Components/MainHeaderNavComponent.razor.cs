using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class MainHeaderNavComponent : ComponentBase
{
    [CascadingParameter] public HeaderComponent? HeaderComponent { get; set; }
    private ElementReference _mainHeaderNavComponent;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        
    }

    public async Task<bool> IsMobileAsync()
    {
        return await _jsRuntime.InvokeAsync<bool>("mobileAndTabletCheck", new object[] { });

    }

    private async Task SetFocusWhenRenderingComponentAsync()
    {
        await _mainHeaderNavComponent.FocusAsync();
    }

    #region Notification Item

    private NotificationComponent _notificationComponent;
    private ElementReference _notificationItemContainerRef;
    private bool isNotificationOpening = false;

    private async Task OnNotification_ClickAsync()
    {
        if (_isMessengerOpening)
        {
            await MessengerMenu_OnFocusOut();
        }
        isNotificationOpening = !isNotificationOpening;
        if (isNotificationOpening) await _notificationItemContainerRef.FocusAsync();
        await _notificationComponent.SetActiveNotificationAsync(isNotificationOpening);
    }

    private async Task OnNotification_OutFocusAsync()
    {
        isNotificationOpening = false;
        await _notificationComponent.SetActiveNotificationAsync(isNotificationOpening);
    }

    #endregion

    #region MessengerRef

    private ElementReference _messengerRef;
    private ElementReference _messengerMenuContainerRef;
    private bool _isMessengerOpening = false;
    private string _styleDisplayLiveChatSubmenu = "display:none;";

    private async Task OnMessenger_ClickAsync()
    {
        _isMessengerOpening = !_isMessengerOpening;
        _styleDisplayLiveChatSubmenu = _isMessengerOpening ? "display:block;" : "display:none;";
        await Task.Delay(200);
    }

    private async Task MessengerMenu_OnFocusOut()
    {
        _isMessengerOpening = false;
        _styleDisplayLiveChatSubmenu = "display:none;";
    }

    private async Task MessengerMenu_iMailMenuItemClickAsync()
    {
        _navigateManager.NavigateTo("/imail", await IsMobileAsync());
        await MessengerMenu_OnFocusOut();
    }

    private async Task MessengerMenu_OpenLiveChatBoxAsync()
    {
        await HeaderComponent._liveChatComponent.SetActiveLiveChat(true);
        await MessengerMenu_OnFocusOut();
        if (await IsMobileAsync())
            await HeaderComponent.BurgerMenu_OnFocusOutAsync();
    }

    #endregion
}
