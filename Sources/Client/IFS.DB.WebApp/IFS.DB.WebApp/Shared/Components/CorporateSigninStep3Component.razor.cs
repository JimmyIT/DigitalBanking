using IFS.DB.WebApp.Models.Identity;
using IFS.DB.WebApp.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using static IFS.DB.WebApp.Helpers.Enums.CorporateSignInEnum;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CorporateSigninStep3Component
{
    [Parameter] public EventCallback<SigninStepsEnum> OnValueChanged { get; set; }
    
    private readonly UserIDModel _model;
    private readonly EditContext _editContext;
    private readonly ValidationMessageStore _messageStore;
    private InputText _txtUserID;

    public CorporateSigninStep3Component()
    {
        _model = new UserIDModel();
        _editContext = new EditContext(_model);
        _messageStore = new ValidationMessageStore(_editContext);
    }

    protected override void OnInitialized()
    {
        _editContext.OnFieldChanged += delegate (object? sender, FieldChangedEventArgs args)
        {
            if (args.FieldIdentifier.Equals(_editContext.Field(nameof(_model.UserID))))
                _messageStore.Clear(_editContext.Field(nameof(_model.UserID)));
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

        if (_model.UserID!.Equals("user1"))
        {
            await OnValueChanged.InvokeAsync(SigninStepsEnum.FourthStep);
            return;
        }

        _messageStore.Clear();
        _messageStore.Add(_editContext.Field(nameof(_model.UserID)),
            "You have entered an invalid User ID.");
        _editContext.NotifyValidationStateChanged();

    }
    
    private Func<SigninStepsEnum, Action> GoToStep => step => async () =>
    {
        if (OnValueChanged.HasDelegate)
            await OnValueChanged.InvokeAsync(step);
    };

    class UserIDModel
    {
        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
        public string? UserID { get; set; }
    }
}
