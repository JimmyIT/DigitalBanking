using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class ProfileSecurityComponent
{
    private UserInfoModel _authorisedUser = FakeData.AuthorisedUser;
    private ChangeSecutityConfigurationsRequestModel _changeSecutityConfigurationsRequestModel;
    private EditContext _profileSecurityConfigEditContext;
    private ValidationMessageStore _validateMsgStore;
    private bool isSuccess = false;
    private string _selectedSecurityFactor = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await EditContextConfiguration();
    }

    private async Task EditContextConfiguration()
    {
        _changeSecutityConfigurationsRequestModel = new ChangeSecutityConfigurationsRequestModel(_authorisedUser.DevicesActiveSessions, _authorisedUser.SecuritySetting);
        _selectedSecurityFactor = _changeSecutityConfigurationsRequestModel.SecuritySetting.ToString();

        _profileSecurityConfigEditContext = new EditContext(_changeSecutityConfigurationsRequestModel);
        _profileSecurityConfigEditContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _validateMsgStore = new ValidationMessageStore(_profileSecurityConfigEditContext);
        _profileSecurityConfigEditContext.OnFieldChanged += (_, args) => { _validateMsgStore.Clear(args.FieldIdentifier); };
    }

    private async Task OnValidSubmit_Click()
    {        
        _authorisedUser.SecuritySetting = _changeSecutityConfigurationsRequestModel.SecuritySetting;
        _authorisedUser.DevicesActiveSessions = _changeSecutityConfigurationsRequestModel.DevicesActiveSessions;

        isSuccess = true;

        await EditContextConfiguration();
    }

    private async Task OnInvalidSubmit_Click()
    {
        isSuccess = false;
    }

    private async Task DeleteSessionDevice(DevicesActiveSessionModel devicesActiveSession)
        => _changeSecutityConfigurationsRequestModel.DevicesActiveSessions.Remove(devicesActiveSession);
    private async Task ChangeSecuritySetting(SecurityFactorEnum selectedType)
    {
        //switch(selectedType)
        //{
        //    case SecurityFactorEnum.OneFactor:
        //        {
        //            _changeSecutityConfigurationsRequestModel.SecuritySetting = SecurityFactorEnum.OneFactor;
        //            break;
        //        }
        //    case SecurityFactorEnum.TwoFactor:
        //        {
        //            break;
        //        }
        //}
    }
}
