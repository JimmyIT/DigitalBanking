using IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.GroupMaintenance;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class UserMaintenanceTableComponent
{
    private EditContext? _searchEditContext;
    private SearchUserModel _searchUserModel = new();

    private UserMaintenanceModel _userMaintenanceModel;
    private List<GroupInfoModel> _listGroups;

    private DataGridComponent<UserInfoModel> _dataSourceGrid;
    private List<ColumnDefinition<UserInfoModel>> _columnsDefinition;
    private PagingConfig _pagingConfig;
    private GroupInfoModel _selectedGroup;
    private List<GroupInfoModel> _selectedSearchGroups;
    private UserActionStatusEnum? _selectedUserActionStatusEnum;
    private string _searchGroup;
    protected override async Task OnInitializedAsync()
    {
        _listGroups = FakeData.Groups;
        _userMaintenanceModel = FakeData.UserMaintenance with { };

        _searchEditContext = new EditContext(_searchUserModel);
        _searchEditContext.SetFieldCssClassProvider(new CustomSearchFieldClassProvider());
        _searchEditContext.OnFieldChanged += EditContext_OnFieldChanged;

        await InitializeDataSourceGrid();
    }

    private async Task InitializeDataSourceGrid()
    {
        if (_columnsDefinition == null)
        {
            _columnsDefinition = new List<ColumnDefinition<UserInfoModel>>();
            _columnsDefinition.AddRange(
            new ColumnDefinition<UserInfoModel>[]{
                    new() { Caption="USER NAME", FragmentTemplateFunc = UserNameWithAvartaTemplate },
                    new() { DataField = "UserID", Caption="USER ID" },
                    new() { DataField = "LastLoggedin", Caption="LAST LOGGED ON" },
                    new() { Caption="PHONE NUMBER", FragmentTemplateFunc = PhoneNumberTemplate },
                    new() { Caption="GROUP", FragmentTemplateFunc = GroupNameTemplate },
                    new() { Caption="STATUS", FragmentTemplateFunc = StatusTemplate },
                    new() { Caption="", FragmentTemplateFunc = ButtonActionTemplate },
            });
        }

        _pagingConfig = new PagingConfig()
        {
            Enabled = true,
            PageSize = 10,
            CustomPager = false
        };

        await Task.CompletedTask;
    }

    private async Task SelectedGroup(GroupInfoModel selectedGroup)
    {
        _selectedGroup = selectedGroup;
    }

    private async Task SaveSelectedGroup(int userID)
    {
        if (_selectedGroup != null)
        {
            FakeData.UserMaintenance.UserInfos.FirstOrDefault(x => x.UserID == userID).GroupID = _selectedGroup.ID;
            _userMaintenanceModel = FakeData.UserMaintenance;
            StateHasChanged();
        }
    }

    private async Task OnSearchGroup(ChangeEventArgs args)
    {
        if (!string.IsNullOrEmpty(args.Value.ToString()))
        {
            _listGroups = _listGroups.Where(x => x.Name.ToUpper().Contains(args.Value.ToString().ToUpper())).ToList();
        }
        else
        {
            _listGroups = FakeData.Groups;
        }
        StateHasChanged();
    }

    private async Task OnValidSubmit()
    {

    }

    private async Task OnInValidSubmit()
    {

    }

    // Note: The OnFieldChanged event is raised for each field in the model
    private async void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        await SearchAsync();
    }

    private async Task SelectedSearchGroupValue(List<GroupInfoModel> selectedGroups)
    {
        _searchUserModel.Groups = selectedGroups; await SearchAsync();
    }

    private async Task SelectedSearchUserActionValue(UserActionStatusEnum? selectedUserAction)
    {
        _searchUserModel.ActionStatus = selectedUserAction; await SearchAsync();
    }

    private async Task SearchAsync()
    {
        _userMaintenanceModel = FakeData.UserMaintenance with { };
        if (!string.IsNullOrEmpty(_searchUserModel.SearchString))
        {
            _userMaintenanceModel.UserInfos = _userMaintenanceModel.UserInfos.Where(user =>
                                                                                            user.UserID.ToString().ToLower().Contains(_searchUserModel.SearchString.ToLower()) ||
                                                                                            user.UserName.ToLower().Contains(_searchUserModel.SearchString.ToLower())).ToList();
            _userMaintenanceModel.TotalRecords = _userMaintenanceModel.UserInfos.Count();
        }

        if (_searchUserModel.Groups?.Count > 0)
        {
            _searchUserModel.Groups.ForEach(x =>
            {
                _userMaintenanceModel.UserInfos = _userMaintenanceModel.UserInfos.Where(user => user.GroupID.GetValueOrDefault() == x.ID).ToList();
                _userMaintenanceModel.TotalRecords = _userMaintenanceModel.UserInfos.Count();
            });
        }

        if (_searchUserModel.ActionStatus.HasValue)
        {
            _userMaintenanceModel.UserInfos = _userMaintenanceModel.UserInfos.Where(user => user.ActionStatus == (UserActionStatusEnum)_searchUserModel.ActionStatus).ToList();
            _userMaintenanceModel.TotalRecords = _userMaintenanceModel.UserInfos.Count();
        }
    }

    private async Task SearchStringOnChange(ChangeEventArgs e)
    {
        _searchUserModel.SearchString = e.Value as string;
        await SearchAsync();
    }

    private async Task Delete(UserInfoModel user)
    {
        _userMaintenanceModel.UserInfos.RemoveAll(x => x.UserID == user.UserID);
        _userMaintenanceModel.TotalRecords = _userMaintenanceModel.UserInfos.Count;
    }
}
