using IFS.DB.WebApp.Features.Admin.Pages;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.GroupMaintenance;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class GroupCreationMembersComponent
{
    [CascadingParameter(Name = "GroupCreation")] public GroupCreation GroupCreation { get; set; }
    [CascadingParameter(Name = "GroupEdit")] public GroupEdit GroupEdit { get; set; }

    private EditContext _groupMembersContext;
    private ValidationMessageStore _validationMessageStore;
    private List<UserInfoModel> _selectedGroupMembers = new List<UserInfoModel>();
    private List<UserInfoModel> _listUsers = new List<UserInfoModel>();
    private List<UserInfoModel> _templistUsers = new List<UserInfoModel>();
    private List<UserInfoModel> _listSelectedUsers = new List<UserInfoModel>();
    private GroupInfoModel _groupInfoModel;

    protected override async Task OnInitializedAsync()
    {
        await LoadListUsersWithoutGroupAsync();
        await PrepareEditContextAsync();
    }

    private async Task LoadListUsersWithoutGroupAsync(string searchStr = "")
    {
        _listUsers = FakeData.UserMaintenance.UserInfos.Select(x => x with { }).ToList();
        _listUsers = _listUsers.Where(x => !x.GroupID.HasValue).ToList();

        if (!string.IsNullOrEmpty(searchStr))
        {
            _listUsers = _listUsers.Where(x => x.UserName.ToLower().Contains(searchStr.ToLower())).ToList();
        }
        _templistUsers = _listUsers;
    }

    private async Task PrepareEditContextAsync()
    {
        if (GroupCreation != null)
        {
            _groupInfoModel = GroupCreation._groupInfoModel;
            _groupInfoModel.GroupMembers = _groupInfoModel.GroupMembers.Select(x => x with { }).ToList() ?? new List<UserInfoModel>();
        }
        else if (GroupEdit != null)
        {
            _groupInfoModel = GroupEdit._groupInfoModel;
            _selectedGroupMembers = _groupInfoModel.GroupMembers?.Select(x => x with { }).ToList() ?? new List<UserInfoModel>();
        }

        _groupMembersContext = new EditContext(_groupInfoModel);
        _groupMembersContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _validationMessageStore = new ValidationMessageStore(_groupMembersContext);

        _groupMembersContext.OnFieldChanged += EditContext_OnFieldChanged;

        if (GroupCreation != null)
        {
            await GroupCreation.AddChildContextAsync(_groupMembersContext);
            await GroupCreation.ForceStateHasChangeAsync();
        }
        else if (GroupEdit != null)
        {
            await GroupEdit.AddChildContextAsync(_groupMembersContext);
            await GroupEdit.ForceStateHasChangeAsync();
        }
    }

    private async void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        _groupInfoModel.GroupMembers = _selectedGroupMembers;
        if (GroupCreation != null)
        {
            await GroupCreation.SetGroupInfoDataRequestAsync(_groupInfoModel);
            await GroupCreation.ContextsHasChangeAsync();
            await GroupCreation.ForceStateHasChangeAsync();
        }
        else if (GroupEdit != null)
        {
            await GroupCreation.SetGroupInfoDataRequestAsync(_groupInfoModel);
            await GroupEdit.ContextsHasChangeAsync();
            await GroupEdit.ForceStateHasChangeAsync();
        }
    }

    #region Dropdown Select User 

    private ElementReference _dropdownSelector;
    private ElementReference _dropdownSearchOption;
    private bool _dropDownOpen = false;
    private bool _keepDropDownOpen = false;
    private async Task OnOpenDropdownUserClickAsync()
    {
        if(_dropDownOpen)
        {
            await _dropdownSelector.FocusAsync();
            StateHasChanged();
        }
    }

    private async Task DropdownStateChangeAsync(bool dropDownOpen)
    {
        _dropDownOpen = dropDownOpen;       
        await OnOpenDropdownUserClickAsync();
    }

    private async Task OutFocusDropdownAsync()
    {
        if (_keepDropDownOpen)
            return;

        await Task.Delay(200);
        await DropdownStateChangeAsync(false);
    }

    private async Task KeepStateWhenClickSearchOptionAsync(bool isKeep)
    {
        _keepDropDownOpen = isKeep;        
        if (!isKeep)
        {
            await OutFocusDropdownAsync();
        }
        else
        {
            await _dropdownSearchOption.FocusAsync();
        }
    }

    #endregion

    private async Task SelectedUser(UserInfoModel userInfo)
    {
        _selectedGroupMembers.Add(userInfo);
        _groupInfoModel.GroupMembers = _selectedGroupMembers;

        if (GroupCreation != null)
        {
            _listUsers.ForEach(x =>
            {
                if (x.UserID == userInfo.UserID)
                {
                    x.GroupID = GroupCreation._groupInfoModel.ID;
                }
            });
            _listUsers = _listUsers.Where(x => !x.GroupID.HasValue).ToList();
            await GroupCreation.SetGroupInfoDataRequestAsync(_groupInfoModel);
        }
        else if (GroupEdit != null)
        {
            _listUsers.ForEach(x =>
            {
                if (x.UserID == userInfo.UserID)
                {
                    x.GroupID = GroupEdit._groupInfoModel.ID;
                }
            });
            _listUsers = _listUsers.Where(x => !x.GroupID.HasValue).ToList();
            await GroupEdit.SetGroupInfoDataRequestAsync(_groupInfoModel);
        }
        _templistUsers = _listUsers;
        _keepDropDownOpen = false;
        await _dropdownSelector.FocusAsync();
        StateHasChanged();
    }

    private async Task DeleteSelectedUser(UserInfoModel userInfo)
    {
        _selectedGroupMembers.Remove(userInfo);
        _groupInfoModel.GroupMembers = _selectedGroupMembers.Select(x => x with { }).ToList();

        userInfo.GroupID = null;
        _listUsers.Add(userInfo);
        
        if (_selectedGroupMembers.Count > 0)
        {
            _selectedGroupMembers.ForEach(selectedUser =>
            {
                _listUsers.RemoveAll(user => user.UserID == selectedUser.UserID);
            });
        }

        _templistUsers = _listUsers;

        if (GroupCreation != null)
        {            
            await GroupCreation.SetGroupInfoDataRequestAsync(_groupInfoModel);
        }
        else if (GroupEdit != null)
        {           
            await GroupEdit.SetGroupInfoDataRequestAsync(_groupInfoModel);
        }
    }

    private async Task SearchStringOnChange(ChangeEventArgs e)
    {
        string searchString = e.Value as string; 
        _listUsers = _templistUsers.Where(x => x.UserName.ToLower().Contains(searchString.ToLower())).ToList();
    }
}
