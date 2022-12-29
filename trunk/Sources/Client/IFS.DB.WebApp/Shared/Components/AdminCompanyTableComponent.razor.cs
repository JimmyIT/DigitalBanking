using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.CompnentConfiguration;
using IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class AdminCompanyTableComponent
{
    [CascadingParameter] IModalService ModalSvc { get; set; } = default!;
    private UserActionsModel UserActions;
    private List<UserInfoModel> LastUsers;
    private DataGridComponent<UserInfoModel> _dataSourceGrid;
    private List<ColumnDefinition<UserInfoModel>> _columnsDefinition;
    private PagingConfig _pagingConfig;

    protected override async Task OnInitializedAsync()
    {
        await InitializeDataSourceGrid();
        UserActions = FakeData.UserActions;
        LastUsers = UserActions.LastUsers;
    }

    private async Task InitializeDataSourceGrid()
    {
        if (_columnsDefinition == null)
        {
            _columnsDefinition = new List<ColumnDefinition<UserInfoModel>>();
            _columnsDefinition.AddRange(
            new ColumnDefinition<UserInfoModel>[]{
                    new() { DataField = "UserName", Caption="USER NAME", FragmentTemplateFunc = UserNameWithAvartaTemplate },
                    new() { DataField = "LastLoggedin", Caption="LAST LOGGED ON", ShowValueFunc = ShowLastTimeValue},
                    new() { DataField = "ActionStatus", Caption="STATUS", FragmentTemplateFunc = StatusTemplate },
                    new() { FragmentTemplateFunc = ButtonActionTemplate },
            });
        }

        _pagingConfig = new PagingConfig()
        {
            Enabled = false,
            PageSize = 10,
            CustomPager = false
        };
        await Task.CompletedTask;
    }

    private string ShowLastTimeValue(UserInfoModel user)
        => !string.IsNullOrEmpty(user.LastLoggedin) ? user.LastLoggedin : "-";

    private async Task ShowModalConfirmDeletion(UserInfoModel user)
    {
        ModalParameters parameters = new ModalParameters()
            .Add(nameof(CommonModalComponent.HeaderLabel), $"Are you sure you want to delete {user.UserName}?")
            .Add(nameof(CommonModalComponent.UseButtonOk), true);

        var options = new ModalOptions
        {
            UseCustomLayout = true
        };
        var modalResult = ModalSvc.Show<CommonModalComponent>($"Are you sure you want to delete this user?", parameters, options);
        var result = await modalResult.Result;
        if (result.Confirmed)
        {
            await DeleteAsync(user);
        }
    }

    private async Task DeleteAsync(UserInfoModel userInfo)
    {
        UserActions.LastUsers.RemoveAll(x => x.UserID == userInfo.UserID);
        UserActions.TotalRecords = UserActions.LastUsers.Count;
    }
}
