using IFS.DB.WebApp.Models.Identity;
using IFS.DB.WebApp.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using static IFS.DB.WebApp.Helpers.Enums.CorporateSignInEnum;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CorporateSigninStep3Component
{
    [CascadingParameter(Name = "UserSignInModel")]
    public UserSignInModel UserSignInModel { get; set; }
    
    [CascadingParameter(Name = "MseAuth")]
    public MseAuth MseAuth { get; set; }
    
    [CascadingParameter(Name = "UserIdModel")]
    public UserIdModel UserIdModel { get; set; }
    [Parameter] public EventCallback<SigninStepsEnum> OnValueChanged { get; set; }

    private EditContext _editContext;
    private ValidationMessageStore _messageStore;
    private InputText _txtUserID;


    protected override void OnInitialized()
    {
        _editContext = new EditContext(UserIdModel);
        _messageStore = new ValidationMessageStore(_editContext);
        _editContext.OnFieldChanged += delegate(object? sender, FieldChangedEventArgs args)
        {
            if (args.FieldIdentifier.Equals(_editContext.Field(nameof(UserIdModel.UserId))))
                _messageStore.Clear(_editContext.Field(nameof(UserIdModel.UserId)));
        };
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (_txtUserID.Element != null)
                await _txtUserID.Element.Value.FocusAsync();
        }
    }

    private void ButtonNextOnClick()
    {
        bool isValid = true;
        if (isValid)
        {
            OnValueChanged.InvokeAsync(SigninStepsEnum.FourthStep);
        }
    }

    private void ButtonBackOnClick()
    {
        bool isValid = true;
        if (isValid)
        {
            OnValueChanged.InvokeAsync(SigninStepsEnum.SecondStep);
        }
    }

    private async Task ProcessStep()
    {
        if (!_editContext.Validate())
            return;

        if (UserIdModel.UserId!.Equals("user1"))
        {
            await OnValueChanged.InvokeAsync(SigninStepsEnum.FourthStep);
            return;
        }

        _messageStore.Clear();
        _messageStore.Add(_editContext.Field(nameof(UserIdModel.UserId)),
            "You have entered an invalid User ID.");
        _editContext.NotifyValidationStateChanged();
    }

    private Func<SigninStepsEnum, Action> GoToStep => step => async () =>
    {
        if (OnValueChanged.HasDelegate)
            await OnValueChanged.InvokeAsync(step);
    };
}