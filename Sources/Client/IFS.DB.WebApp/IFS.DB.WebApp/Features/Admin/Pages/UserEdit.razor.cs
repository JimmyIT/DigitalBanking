using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.Attributes;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.Extensions;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Users;
using IFS.DB.WebApp.Shared.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Features.Admin.Pages;

public partial class UserEdit
{
    [CascadingParameter] IModalService ModalSvc { get; set; } = default!;
    [QueryStringParameter] public string UserID { get; set; }

    private int? _selectedUserID;
    private readonly List<EditContext> _userMaintenanceContexts = new();
    internal UserCreationRequestModel _userCreationRequestModel = new();
    private bool IsContextInValid = true;

    internal async Task AddChildContextAsync(EditContext ctx) => _userMaintenanceContexts.Add(ctx);
    internal async Task ContextsHasChangeAsync()
    {
        IsContextInValid = _userMaintenanceContexts.Any(x => x.Validate() is false);
    }

    internal async Task ForceStateHasChangeAsync()
    {
        StateHasChanged();
    }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        // 👇 Read the value of each property decorated by [QueryStringParameter] from the query string
        this.SetParametersFromQueryString(_navigateManager);
        await base.SetParametersAsync(parameters);
    }

    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(UserID))
        {
            _selectedUserID = int.Parse(UserID);
        }

        if (!_selectedUserID.HasValue)
        {
            await ErrorMessageShow("Error", "The url is not correct, please try again.");
            return;
        }

        UserInfoModel userInfoModel = await GetUserInfo();
        if (userInfoModel == null)
        {
            await ErrorMessageShow("Error", $"User with ID - {UserID} does not exist.");
            return;
        }

        await PrepareUserInfoToEdit(userInfoModel);
    }

    private async Task ErrorMessageShow(string modalTitle, string erroMsg)
    {
        ModalParameters parameters = new ModalParameters()
            .Add(nameof(CommonModalComponent.Message), $"{erroMsg}")
            .Add(nameof(CommonModalComponent.HeaderLabel), $"{modalTitle}")
            .Add(nameof(CommonModalComponent.UseButtonOk), true)
            .Add(nameof(CommonModalComponent.EventOkClick), EventCallback.Factory.Create(this, NavigateTo));

        var options = new ModalOptions
        {
            UseCustomLayout = true
        };
        ModalSvc.Show<CommonModalComponent>($"{modalTitle}", parameters, options);
    }

    private async Task NavigateTo()
        => _navigateManager.NavigateTo("/company-admin/user-maintenance");

    private async Task<UserInfoModel> GetUserInfo()
        => FakeData.UserMaintenance.UserInfos.Where(x => x.UserID == _selectedUserID.GetValueOrDefault()).FirstOrDefault();

    private async Task PrepareUserInfoToEdit(UserInfoModel userInfoModel)
    {
        _userCreationRequestModel.UserId = userInfoModel.UserID;
        _userCreationRequestModel.UserName = userInfoModel.UserName;
        _userCreationRequestModel.PhoneNumberIDD = userInfoModel.PhoneNumberIDD;
        _userCreationRequestModel.PhoneNumber = userInfoModel.PhoneNumber;
        _userCreationRequestModel.EmailAddress = userInfoModel.Email;
        _userCreationRequestModel.GroupID = userInfoModel.GroupID;
        _userCreationRequestModel.ActionStatus = userInfoModel.ActionStatus;
        _userCreationRequestModel.UserPreference = userInfoModel.UserPreference ?? null;
    }

    private async Task OnSaveUpdates()
    {
        if (_userMaintenanceContexts.Any(x => x.Validate() is false))
            return;


        var parameters = new ModalParameters();
        parameters.Add(nameof(AdminUserModalUpdate.UserCreationRequestModel), _userCreationRequestModel);

        FakeData.UserMaintenance.UserInfos.ForEach(x =>
        {
            if (x.UserID == _userCreationRequestModel.UserId)
            {
                x.UserID = _userCreationRequestModel.UserId;
                x.UserName = _userCreationRequestModel.UserName;
                x.Email = _userCreationRequestModel.EmailAddress;
                x.PhoneNumberIDD = _userCreationRequestModel.PhoneNumberIDD;
                x.PhoneNumber = _userCreationRequestModel.PhoneNumber;
                x.GroupID = _userCreationRequestModel.GroupID;
                x.UserPreference = _userCreationRequestModel.UserPreference;
                x.ActionStatus = _userCreationRequestModel.ActionStatus.GetValueOrDefault();
            }
        });

        var options = new ModalOptions
        {
            UseCustomLayout = true
        };
        ModalSvc.Show<AdminUserModalUpdate>("User update confirm", parameters, options);
    }

    private async Task ShowConfirmLockUserModal()
    {
        if (_userCreationRequestModel.ActionStatus.GetValueOrDefault().Equals(UserActionStatusEnum.Confirmed))
        {
            ModalParameters parameters = new ModalParameters()
                .Add(nameof(AdminUserModalLock.UserInfoModel), _userCreationRequestModel);

            var options = new ModalOptions
            {
                UseCustomLayout = true
            };

            var updatedUser = ModalSvc.Show<AdminUserModalLock>($"Locked User Modal", parameters, options);
            var result = await updatedUser.Result;
            if (result.Confirmed)
            {
                _userCreationRequestModel = (UserCreationRequestModel)result.Data;

                FakeData.UserMaintenance.UserInfos.ForEach(x =>
                {
                    if (x.UserID == _userCreationRequestModel.UserId)
                    {
                        x.ActionStatus = _userCreationRequestModel.ActionStatus.GetValueOrDefault();
                    }
                });

            }
        }
        else if (_userCreationRequestModel.ActionStatus.GetValueOrDefault().Equals(UserActionStatusEnum.AwaitingSignoff))
        {
            ModalParameters parameters = new ModalParameters()
                .Add(nameof(AdminUserModalConfirm.UserInfoModel), _userCreationRequestModel);

            var options = new ModalOptions
            {
                UseCustomLayout = true
            };

            var updatedUser = ModalSvc.Show<AdminUserModalConfirm>($"Confirm Lock User Modal", parameters, options);
            var result = await updatedUser.Result;
            if (result.Confirmed)
            {
                _userCreationRequestModel = (UserCreationRequestModel)result.Data;

                FakeData.UserMaintenance.UserInfos.ForEach(x =>
                {
                    if (x.UserID == _userCreationRequestModel.UserId)
                    {
                        x.ActionStatus = _userCreationRequestModel.ActionStatus.GetValueOrDefault();
                    }
                });

            }
        }
    }

    private async Task RejectLockUser()
    {
        _userCreationRequestModel.ActionStatus = UserActionStatusEnum.Confirmed;
        FakeData.UserMaintenance.UserInfos.ForEach(x =>
        {
            if (x.UserID == _userCreationRequestModel.UserId)
            {
                x.ActionStatus = UserActionStatusEnum.Confirmed;
            }
        });
    }
}
