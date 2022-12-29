using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class AdminUserModalConfirm
{

    [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;
    [Parameter] public UserCreationRequestModel UserInfoModel { get; set; }

    private async Task Cancel() => await BlazoredModal.CancelAsync();
    private async Task OnLockUser()
    {
        UserInfoModel.ActionStatus = UserActionStatusEnum.Locked;
        await BlazoredModal.CloseAsync(ModalResult.Ok(UserInfoModel));
    }
}
