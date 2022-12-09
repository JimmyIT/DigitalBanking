using IFS.DB.WebApp.Helpers.Constants;
using IFS.DB.WebApp.Models.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using static IFS.DB.WebApp.Helpers.Enums.CorporateSignInEnum;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CorporateSigninStep1Component
{
    [Parameter] public EventCallback<SigninStepsEnum> OnValueChanged { get; set; }

    private readonly UserSignInModel _userSignInModel;
    private readonly EditContext _editContext;
    private readonly ValidationMessageStore _messageStore;
    private InputText _txtCustomerID;

    public CorporateSigninStep1Component()
    {
        _userSignInModel = new();
        _editContext = new EditContext(_userSignInModel);
        _messageStore = new ValidationMessageStore(_editContext);
    }

    protected override void OnInitialized()
    {
        _editContext.OnFieldChanged += (object? sender, FieldChangedEventArgs args) =>
        {
            if (args.FieldIdentifier.Equals(_editContext.Field(nameof(_userSignInModel.CustomerID))))
                _messageStore.Clear(_editContext.Field(nameof(_userSignInModel.CustomerID)));
        };
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if(firstRender)
        {
            if (_txtCustomerID.Element != null)
                await _txtCustomerID.Element.Value.FocusAsync();
        }
    }

    private async Task ProcessStep()
    {
        if (!_editContext.Validate())
            return;

        if (_userSignInModel.CustomerID.ToLower().Contains("customer"))
        {
            UserSignInModel userSignInModel = new()
            {
                Role = UserRoles.MSECustomer,
                UserID = "Craig",
                ClientNumber = "00088",
                CustomerID = "Craig"
            };
            await _localStorageSvc.SetItemAsync<UserSignInModel>("Identity", userSignInModel);
            await OnValueChanged.InvokeAsync(SigninStepsEnum.SecondStep);
            return;
        }
        else if (_userSignInModel.CustomerID.ToLower().Contains("admin"))
        {
            UserSignInModel userSignInModel = new()
            {
                Role = UserRoles.Admin,
                UserID = "Craig",
                ClientNumber = "00088",
                CustomerID = "Craig"
            };
            await _localStorageSvc.SetItemAsync<UserSignInModel>("Identity", userSignInModel);
            await OnValueChanged.InvokeAsync(SigninStepsEnum.SecondStep);
            return;
        }
        else if (_userSignInModel.CustomerID.ToLower().Contains("host"))
        {
            UserSignInModel userSignInModel = new()
            {
                Role = UserRoles.Host,
                UserID = "Craig",
                ClientNumber = "00088",
                CustomerID = "Craig"
            };
            await _localStorageSvc.SetItemAsync<UserSignInModel>("Identity", userSignInModel);
            await OnValueChanged.InvokeAsync(SigninStepsEnum.SecondStep);
            return;
        }

        _messageStore.Clear();
        _messageStore.Add(_editContext.Field(nameof(_userSignInModel.CustomerID)), "You have entered an invalid Customer ID.");
        _editContext.NotifyValidationStateChanged();
    }

}