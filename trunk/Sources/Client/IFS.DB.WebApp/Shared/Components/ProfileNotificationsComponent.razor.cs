using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class ProfileNotificationsComponent
{
    private NotificationConfigurationModel _userNotificationConfiguration = FakeData.AuthorisedUser.NotificationSettings;
    private ChangeNotificationConfigurationsRequestModel _changeNotificationRequestModel;
    private EditContext _profileNotificationConfigEditContext;
    private ValidationMessageStore _validateMsgStore;
    private bool isSuccess = false;
    protected override async Task OnInitializedAsync()
    {
        await EditContextConfiguration();
    }

    private async Task EditContextConfiguration()
    {
        _changeNotificationRequestModel = new ChangeNotificationConfigurationsRequestModel()
        {
            InformMessagesFromManagerEmail = _userNotificationConfiguration.InformMessagesFromManagerEmail,
            InformMessagesFromManagerSMS = _userNotificationConfiguration.InformMessagesFromManagerSMS,
            InformMessagesFromManageriMail = _userNotificationConfiguration.InformMessagesFromManageriMail,

            InformNewBankServicesiMail = _userNotificationConfiguration.InformNewBankServicesiMail,
            InformNewBankServicesEmail = _userNotificationConfiguration.InformNewBankServicesEmail,
            InformNewBankServicesSMS = _userNotificationConfiguration.InformNewBankServicesSMS,

            InformTransactionsSMS = _userNotificationConfiguration.InformTransactionsSMS,
            InformTransactionsEmail = _userNotificationConfiguration.InformTransactionsEmail,
            InformTransactionsiMail = _userNotificationConfiguration.InformTransactionsiMail,
        };
        _profileNotificationConfigEditContext = new EditContext(_changeNotificationRequestModel);
        _profileNotificationConfigEditContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _validateMsgStore = new ValidationMessageStore(_profileNotificationConfigEditContext);
        _profileNotificationConfigEditContext.OnFieldChanged += (_, args) => { _validateMsgStore.Clear(args.FieldIdentifier); };
    }

    private async Task OnValidSubmit_Click()
    {
        _userNotificationConfiguration = new NotificationConfigurationModel()
        {
            InformTransactionsSMS = _changeNotificationRequestModel.InformTransactionsSMS,
            InformTransactionsEmail = _changeNotificationRequestModel.InformTransactionsEmail,
            InformTransactionsiMail = _changeNotificationRequestModel.InformTransactionsiMail,

            InformNewBankServicesSMS = _changeNotificationRequestModel.InformNewBankServicesSMS,
            InformNewBankServicesEmail = _changeNotificationRequestModel.InformNewBankServicesEmail,
            InformNewBankServicesiMail = _changeNotificationRequestModel.InformNewBankServicesiMail,

            InformMessagesFromManageriMail = _changeNotificationRequestModel.InformMessagesFromManageriMail,
            InformMessagesFromManagerSMS = _changeNotificationRequestModel.InformMessagesFromManagerSMS,
            InformMessagesFromManagerEmail = _changeNotificationRequestModel.InformMessagesFromManagerEmail,
        };
        FakeData.AuthorisedUser.NotificationSettings = _userNotificationConfiguration;
        isSuccess = true;        

        await EditContextConfiguration();
    }

    private async Task OnInvalidSubmit_Click()
    {
        isSuccess = false;
    }
}
