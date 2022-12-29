using IFS.DB.WebApp.Features.Admin.Pages;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models.GroupMaintenance;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class GroupCreationDetailsComponent
{
    [CascadingParameter(Name = "GroupCreation")] public GroupCreation GroupCreation { get; set; }
    [CascadingParameter(Name = "GroupEdit")] public GroupEdit GroupEdit { get; set; }

    private GroupInfoModel _groupInfoModel;
    private EditContext _groupCreationDetailsContext;
    private ValidationMessageStore _validationMessageStore;

    private Random _random = new Random();

    protected override async Task OnInitializedAsync()
    {
        await PrepareEditContextAsync();
    }

    private async Task PrepareEditContextAsync()
    {
        if(GroupCreation != null)
        {
            _groupInfoModel = GroupCreation._groupInfoModel;
            _groupInfoModel.ID = _random.Next(0, 2147483647);
            _groupInfoModel.Description = string.Empty;
            _groupInfoModel.GroupMembers = new List<UserInfoModel>();
        }
        else if(GroupEdit != null)
        {
            _groupInfoModel = GroupEdit._groupInfoModel;
            StateHasChanged();
        }        

        _groupCreationDetailsContext = new EditContext(_groupInfoModel);
        _groupCreationDetailsContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _validationMessageStore = new ValidationMessageStore(_groupCreationDetailsContext);

        _groupCreationDetailsContext.OnFieldChanged += EditContext_OnFieldChanged;

        if (GroupCreation != null)
        {
            await GroupCreation.AddChildContextAsync(_groupCreationDetailsContext);
            await GroupCreation.ForceStateHasChangeAsync();
        }
        else if (GroupEdit != null)
        {
            await GroupEdit.AddChildContextAsync(_groupCreationDetailsContext);
            await GroupEdit.ForceStateHasChangeAsync();
        }
    }

    private async void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        if (GroupCreation != null)
        {
            await GroupCreation.SetGroupInfoDataRequestAsync(_groupInfoModel);
            await GroupCreation.ContextsHasChangeAsync();
            await GroupCreation.ForceStateHasChangeAsync();
        }
        else if (GroupEdit != null)
        {
            await GroupEdit.SetGroupInfoDataRequestAsync(_groupInfoModel);
            await GroupEdit.ContextsHasChangeAsync();
            await GroupEdit.ForceStateHasChangeAsync();
        }
    }
}
