using IFS.DB.WebApp.Helpers.Constants;
using IFS.DB.WebApp.Models.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using static IFS.DB.WebApp.Helpers.Enums.CorporateSignInEnum;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CorporateSigninStep1Component
{
    
    [CascadingParameter(Name = "UserSignInModel")]
    public UserSignInModel UserSignInModel { get; set; }
    
    [CascadingParameter(Name = "MseAuth")]
    public MseAuth MseAuth { get; set; }
    
    [CascadingParameter(Name = "UserIdModel")]
    public UserIdModel UserIdModel { get; set; }
    
    [Parameter] public EventCallback<SigninStepsEnum> OnValueChanged { get; set; }

    private  EditContext _editContext;
    private  ValidationMessageStore _messageStore;
    private InputText _txtCustomerID;

    protected override void OnInitialized()
    {
        _editContext = new EditContext(UserSignInModel);
        _messageStore = new ValidationMessageStore(_editContext);
        _editContext.OnFieldChanged += (object? sender, FieldChangedEventArgs args) =>
        {
            if (args.FieldIdentifier.Equals(_editContext.Field(nameof(UserSignInModel.CustomerID))))
                _messageStore.Clear(_editContext.Field(nameof(UserSignInModel.CustomerID)));
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
        
        if (UserSignInModel.CustomerID.Equals("customer", StringComparison.CurrentCulture)
            || UserSignInModel.CustomerID.Equals("admin", StringComparison.CurrentCulture)
            || UserSignInModel.CustomerID.Equals("host", StringComparison.CurrentCulture))
        {
            await OnValueChanged.InvokeAsync(SigninStepsEnum.SecondStep);
            return;
        }

        _messageStore.Clear();
        _messageStore.Add(_editContext.Field(nameof(UserSignInModel.CustomerID)), "You have entered an invalid Customer ID.");
        _editContext.NotifyValidationStateChanged();
    }

}