using IFS.DB.WebApp.Helpers.CompnentConfiguration;
using IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Users;

namespace IFS.DB.WebApp.Shared.Components;

public partial class AdminCompanyTableComponent
{
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
}
