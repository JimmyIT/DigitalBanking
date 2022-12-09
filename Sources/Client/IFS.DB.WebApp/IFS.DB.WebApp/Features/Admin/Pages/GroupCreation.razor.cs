using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.GroupMaintenance;
using IFS.DB.WebApp.Shared.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Features.Admin.Pages;

public partial class GroupCreation
{
    [CascadingParameter] IModalService ModalSvc { get; set; } = default!;

    internal GroupInfoModel _groupInfoModel = new();
    private readonly List<EditContext> _groupMaintenanceContexts = new();
    private bool IsContextInValid = true;

    internal async Task AddChildContextAsync(EditContext ctx) => _groupMaintenanceContexts.Add(ctx);
    internal async Task ContextsHasChangeAsync() => IsContextInValid = _groupMaintenanceContexts.Any(x => x.Validate() is false);
    internal async Task ForceStateHasChangeAsync() => StateHasChanged();
    internal async Task SetGroupInfoDataRequestAsync(GroupInfoModel groupInfoModel)
    {
        _groupInfoModel = groupInfoModel;
        _groupInfoModel.TotalMembers = groupInfoModel.GroupMembers.Count;
        await ForceStateHasChangeAsync();
    }
    internal async Task SetGroupMembersDataRequestAsync(GroupInfoModel groupInfoModel) 
    {
        _groupInfoModel.GroupMembers = groupInfoModel.GroupMembers;
        _groupInfoModel.TotalMembers = groupInfoModel.GroupMembers.Count;
        await ForceStateHasChangeAsync();
    }

    private async Task OnSave()
    {
        if (_groupMaintenanceContexts.Any(x => x.Validate() is false))
            return;
                
        var parameters = new ModalParameters();
        parameters.Add(nameof(GroupCreationNotificationModal.GroupInfo), _groupInfoModel);

        var options = new ModalOptions
        {
            UseCustomLayout = true
        };

        FakeData.GroupMaintenance.Groups.Add(new GroupInfoModel
        {
            ID = _groupInfoModel.ID,
            Name = _groupInfoModel.Name,
            Description = _groupInfoModel.Description,
            GroupMembers = _groupInfoModel.GroupMembers,
            TotalMembers = _groupInfoModel.TotalMembers
        });
        FakeData.GroupMaintenance.TotalRecords = FakeData.GroupMaintenance.Groups.Count;

        ModalSvc.Show<GroupCreationNotificationModal>("group creation", parameters, options);
    }
}
