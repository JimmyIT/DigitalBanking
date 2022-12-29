using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Users;
using IFS.DB.WebApp.Shared.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Features.Admin.Pages;

public partial class UserCreation
{
    [CascadingParameter] IModalService ModalSvc { get; set; } = default!;


    internal UserCreationRequestModel _userCreationRequestModel = new();
    private readonly List<EditContext> _userMaintenanceContexts = new();
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

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {

        }
    }

    private async Task OnSave()
    {
        if (_userMaintenanceContexts.Any(x => x.Validate() is false))
            return;

        FakeData.UserMaintenance.UserInfos.Add(new UserInfoModel()
        {
            UserID = _userCreationRequestModel.UserId,
            UserName = _userCreationRequestModel.UserName,
            Email = _userCreationRequestModel.EmailAddress,
            PhoneNumberIDD = _userCreationRequestModel.PhoneNumberIDD,
            PhoneNumber = _userCreationRequestModel.PhoneNumber,
            GroupID = _userCreationRequestModel.GroupID,
            UserPreference = _userCreationRequestModel.UserPreference,
            LastLoggedin = string.Empty,
            ActionStatus = UserActionStatusEnum.AwaitingSignoff,
            AvartaUrl = string.Empty,
            FirstName = string.Empty,
            MiddleName = string.Empty,
            LastName = string.Empty,            
        });
        FakeData.UserMaintenance.TotalRecords = FakeData.UserMaintenance.UserInfos.Count;

        var parameters = new ModalParameters();
        parameters.Add(nameof(UserCreationNotificationModal.UserCreationRequestModel), _userCreationRequestModel);

        var options = new ModalOptions
        {
            UseCustomLayout = true
        };
        ModalSvc.Show<UserCreationNotificationModal>("User creation confirm", parameters, options);
    }
}
