using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.Constants;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Identity;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class MainHeaderProfileComponent
{

    [CascadingParameter] public HeaderComponent? HeaderComponent { get; set; }

    [CascadingParameter] IModalService HeaderComponentModalSvc { get; set; } = default!;

    private ElementReference _profileMenuContainer;
    private ElementReference _profileMenuItemsContainer;
    private UserInfoModel _AuthorisedUser = FakeData.AuthorisedUser;
    private bool isProfileMenuOpening = false;
    private string _styleDisplayProfileSubmenu = "display: none;";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if(isProfileMenuOpening)
        {
            await _profileMenuContainer.FocusAsync();
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task ProfileMenu_OnclickAsync()
    {
        isProfileMenuOpening = !isProfileMenuOpening;
        _styleDisplayProfileSubmenu = isProfileMenuOpening ? "display: block;" : "display: none;";
    }

    private async Task ProfileMenu_OnFocusOutAsync()
    {
        isProfileMenuOpening = false;
        _styleDisplayProfileSubmenu = "display:none;";
    }

    private async Task ProfileMenuItemButton_OnclickAsync()
    {
        _navigateManager.NavigateTo("/profile", await IsMobileAsync());
        await ProfileMenu_OnFocusOutAsync();
    }

    public async Task<bool> IsMobileAsync()
    {
        return await _jsRuntime.InvokeAsync<bool>("mobileAndTabletCheck", new object[] { });

    }

    #region Sign out Event Click

    private async Task ProfileMenu_OnclickSignOutAsync()
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
        await ProfileMenu_OnFocusOutAsync();
        if (await IsMobileAsync())
            await HeaderComponent.BurgerMenu_OnFocusOutAsync();
    }

    private async Task ConfirmedSignOut()
    {
        var userSignIn = await _localStorageSvc.GetItemAsync<UserSignInModel>("Identity");
        var url = userSignIn.Role switch
        {
            UserRoles.SSECustomer => "/individual-signin",
            UserRoles.MSECustomer or  UserRoles.Host or  UserRoles.Admin => "/corporate-signin",
            _ => throw new ArgumentOutOfRangeException()
        };
        await _localStorageSvc.RemoveItemAsync("Identity");
        _navigateManager.NavigateTo(url, forceLoad: true);
    }

    #endregion
}
