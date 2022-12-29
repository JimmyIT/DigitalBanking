using IFS.DB.WebApp.Features.Admin.Pages;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.GroupMaintenance;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Text.Json;

namespace IFS.DB.WebApp.Shared.Components;

public partial class UserCreationDetailsComponent
{
    [CascadingParameter(Name = "UserCreation")] protected UserCreation UserCreation { get; set; }
    [CascadingParameter(Name = "UserEdit")] protected UserEdit UserEdit { get; set; }

    [Parameter] public bool IsConfirmLocked { get; set; }

    private EditContext _userCreationDetailsContext;
    private UserCreationRequestModel _userCreationRequestDetails;
    private ValidationMessageStore _validationMessageStore;
    private List<CultureInfoModel> _listCulturesModel = new List<CultureInfoModel>();
    private List<GroupInfoModel> _listGroupMaintenanceModel = new List<GroupInfoModel>();
    private bool _isJustConfirmLocked = false;

    public UserCreationDetailsComponent()
    {

    }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);
        _isJustConfirmLocked = IsConfirmLocked;
        await base.SetParametersAsync(parameters);
    }

    protected override async Task OnParametersSetAsync()
    {
        
    }

    protected override async Task OnInitializedAsync()
    {
        string jsonCultures = File.ReadAllText("wwwroot/default-data/CultureSettings.json");
        _listCulturesModel = JsonSerializer.Deserialize<List<CultureInfoModel>>(jsonCultures);
        _listGroupMaintenanceModel = FakeData.Groups;

        await PrepareEditContextAsync();
        _userCreationRequestDetails.PhoneNumberIDD = _listCulturesModel[0].PhoneNumberIDD;
    }

    private async Task PrepareEditContextAsync()
    {
        if (UserCreation != null)
        {
            _userCreationRequestDetails = UserCreation._userCreationRequestModel;
        }
        else if (UserEdit != null)
        {
            _userCreationRequestDetails = UserEdit._userCreationRequestModel;
        }        

        _userCreationDetailsContext = new EditContext(_userCreationRequestDetails);
        _userCreationDetailsContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _validationMessageStore = new ValidationMessageStore(_userCreationDetailsContext);

        _userCreationDetailsContext.OnFieldChanged += EditContext_OnFieldChanged;

        if(UserCreation != null)
        {
            await UserCreation.AddChildContextAsync(_userCreationDetailsContext);
            await UserCreation.ForceStateHasChangeAsync();
        }
        else if(UserEdit != null)
        {
            await UserEdit.AddChildContextAsync(_userCreationDetailsContext);
            await UserEdit.ForceStateHasChangeAsync();
        }
    }

    private async Task OnSelectedPhoneNumberIDD(CultureInfoModel selectedCulture)
        => _userCreationRequestDetails.PhoneNumberIDD = selectedCulture.PhoneNumberIDD;

    private async Task OnSelectedLanguage(CultureInfoModel selectedCulture)
        => _userCreationRequestDetails.Language = selectedCulture.Language;

    private async Task OnSelectedGroup(GroupInfoModel selectedGroupMaintenance)
        => _userCreationRequestDetails.GroupID = selectedGroupMaintenance.ID;

    private async void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        // TODO:
        // validate Phone IDD, Language
        if (UserCreation != null)
        {
            UserCreation._userCreationRequestModel = _userCreationRequestDetails;
            await UserCreation.ContextsHasChangeAsync();
            await UserCreation.ForceStateHasChangeAsync();
        }
        else if (UserEdit != null)
        {
            UserEdit._userCreationRequestModel = _userCreationRequestDetails;
            await UserEdit.ContextsHasChangeAsync();
            await UserEdit.ForceStateHasChangeAsync();
        }        
    }
}
