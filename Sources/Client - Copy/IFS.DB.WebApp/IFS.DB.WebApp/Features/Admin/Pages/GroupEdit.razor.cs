using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.Attributes;
using IFS.DB.WebApp.Helpers.Extensions;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.GroupMaintenance;
using IFS.DB.WebApp.Shared.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Features.Admin.Pages;

public partial class GroupEdit
{
    [CascadingParameter] IModalService ModalSvc { get; set; } = default!;
    [QueryStringParameter] public string GroupID { get; set; }

    internal GroupInfoModel _groupInfoModel = new();
    private readonly List<EditContext> _groupMaintenanceContexts = new();
    private bool IsContextInValid = true;
    private int? _selectedGroupID;

    private GroupInfoModel _updatedGroupInfoModel = new();

    internal async Task AddChildContextAsync(EditContext ctx) => _groupMaintenanceContexts.Add(ctx);
    internal async Task ContextsHasChangeAsync() => IsContextInValid = _groupMaintenanceContexts.Any(x => x.Validate() is false);
    internal async Task ForceStateHasChangeAsync() => StateHasChanged();
    internal async Task SetGroupInfoDataRequestAsync(GroupInfoModel groupInfoModel)
    {
        _updatedGroupInfoModel = groupInfoModel;
        _updatedGroupInfoModel.TotalMembers = groupInfoModel.GroupMembers.Count;
        await ForceStateHasChangeAsync();
    }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        // 👇 Read the value of each property decorated by [QueryStringParameter] from the query string
        this.SetParametersFromQueryString(_navigateManager);
        await base.SetParametersAsync(parameters);
    }

    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(GroupID))
        {
            _selectedGroupID = int.Parse(GroupID);
        }

        if (!_selectedGroupID.HasValue)
        {
            await ErrorMessageShow("Error", "The url is not correct, please try again.");
            return;
        }

        _groupInfoModel = await GetGroupInfo();
        _updatedGroupInfoModel = _groupInfoModel;
        if (_groupInfoModel == null)
        {
            await ErrorMessageShow("Error", $"User with ID - {GroupID} does not exist.");
            return;
        }
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
        => _navigateManager.NavigateTo("/admin/group-maintenance");

    private async Task<GroupInfoModel> GetGroupInfo()
    {
        List<GroupInfoModel> listAllGroup = FakeData.GroupMaintenance.Groups.Select(x => x with { }).ToList();
        GroupInfoModel group = listAllGroup.Where(x => x.ID == _selectedGroupID.GetValueOrDefault()).FirstOrDefault();

        return group;
    }

    private async Task OnSaveUpdates()
    {
        if (_groupMaintenanceContexts.Any(x => x.Validate() is false))
            return;

        var parameters = new ModalParameters();
        parameters.Add(nameof(GroupCreationNotificationModal.GroupInfo), _updatedGroupInfoModel);

        var options = new ModalOptions
        {
            UseCustomLayout = true
        };

        FakeData.GroupMaintenance.Groups.ForEach(x =>
        {
            if(x.ID == _updatedGroupInfoModel.ID)
            {
                x.Name = _updatedGroupInfoModel.Name;
                x.Description = _updatedGroupInfoModel.Description;
                x.GroupMembers = _updatedGroupInfoModel.GroupMembers;
                x.TotalMembers = _updatedGroupInfoModel.TotalMembers;
            }
        });
        FakeData.GroupMaintenance.TotalRecords = FakeData.GroupMaintenance.Groups.Count;

        ModalSvc.Show<GroupCreationNotificationModal>("group edit", parameters, options);
    }
}
