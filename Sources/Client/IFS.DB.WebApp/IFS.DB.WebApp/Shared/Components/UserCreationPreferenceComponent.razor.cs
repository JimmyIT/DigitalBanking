using IFS.DB.WebApp.Features.Admin.Pages;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class UserCreationPreferenceComponent
{
    [CascadingParameter(Name = "UserCreation")] protected UserCreation UserCreation { get; set; }
    [CascadingParameter(Name = "UserEdit")] protected UserEdit UserEdit { get; set; }

    private EditContext _userPreferenceCreationDetailsContext;
    private UserPreferenceModel _userPreference;
    private ValidationMessageStore _validationMessageStore;

    protected override async Task OnInitializedAsync()
    {
        await PrepareEditContextAsync();
    }

    private async Task PrepareEditContextAsync()
    {
        if (UserCreation != null)
        {
            _userPreference = new UserPreferenceModel()
            {
                UsePaymentPreferences = new List<UsePaymentPreferenceEnum>(),
                UseTransferPreferences = new List<UseTransferPreferenceEnum>(),
                CustomerAccesses = new List<CustomerAccessEnum>()
            };
        }
        else if (UserEdit != null)
        {
            _userPreference = UserEdit._userCreationRequestModel.UserPreference;
            if (_userPreference == null)
            {
                _userPreference = new UserPreferenceModel()
                {
                    UsePaymentPreferences = new List<UsePaymentPreferenceEnum>(),
                    UseTransferPreferences = new List<UseTransferPreferenceEnum>(),
                    CustomerAccesses = new List<CustomerAccessEnum>()
                };
            }
        }

        _userPreferenceCreationDetailsContext = new EditContext(_userPreference);
        _userPreferenceCreationDetailsContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _validationMessageStore = new ValidationMessageStore(_userPreferenceCreationDetailsContext);
        _userPreferenceCreationDetailsContext.OnFieldChanged += EditContext_OnFieldChanged;

        if (UserCreation != null)
        {
            await UserCreation.AddChildContextAsync(_userPreferenceCreationDetailsContext);
            await UserCreation.ForceStateHasChangeAsync();
        }
        else if (UserEdit != null)
        {
            await UserEdit.AddChildContextAsync(_userPreferenceCreationDetailsContext);
            await UserEdit.ForceStateHasChangeAsync();
        }
    }

    private async void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        if (UserCreation != null)
        {
            UserCreation._userCreationRequestModel.UserPreference = _userPreference;
            await UserCreation.ContextsHasChangeAsync();
            await UserCreation.ForceStateHasChangeAsync();
        }
        else if (UserEdit != null)
        {
            UserEdit._userCreationRequestModel.UserPreference = _userPreference;
            await UserEdit.ContextsHasChangeAsync();
            await UserEdit.ForceStateHasChangeAsync();
        }

    }

    private async Task PaymentPreferencesCheckboxes_Clicked(UsePaymentPreferenceEnum checkedEnum, object checkedValue)
    {
        if ((bool)checkedValue)
        {
            _userPreference.UsePaymentPreferences.Add(checkedEnum);
        }
        else
        {
            _userPreference.UsePaymentPreferences.Remove(checkedEnum);
        }
    }

    private async Task TransferPreferencesCheckboxes_Clicked(UseTransferPreferenceEnum checkedEnum, object checkedValue)
    {
        if ((bool)checkedValue)
        {
            _userPreference.UseTransferPreferences.Add(checkedEnum);
        }
        else
        {
            _userPreference.UseTransferPreferences.Remove(checkedEnum);
        }
    }

    private async Task CustomerAccessPreferencesCheckboxes_Clicked(CustomerAccessEnum checkedEnum, object checkedValue)
    {
        if ((bool)checkedValue)
        {
            _userPreference.CustomerAccesses.Add(checkedEnum);
        }
        else
        {
            _userPreference.CustomerAccesses.Remove(checkedEnum);
        }
    }
}
