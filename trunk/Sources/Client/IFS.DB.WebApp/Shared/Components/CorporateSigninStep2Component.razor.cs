using System.ComponentModel.DataAnnotations;
using IFS.DB.WebApp.Models.Identity;
using IFS.DB.WebApp.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using static IFS.DB.WebApp.Helpers.Enums.CorporateSignInEnum;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CorporateSigninStep2Component
{
    
    [CascadingParameter(Name = "UserSignInModel")]
    public UserSignInModel UserSignInModel { get; set; }
    
    [CascadingParameter(Name = "MseAuth")]
    public MseAuth MseAuth { get; set; }
    
    [CascadingParameter(Name = "UserIdModel")]
    public UserIdModel UserIdModel { get; set; }
    
    [Parameter] public EventCallback<SigninStepsEnum> OnValueChanged { get; set; }

    private EditContext _editContext;
    private  ValidationMessageStore _messageStore;
    private InputText _txtMseCode;

    protected override void OnInitialized()
    {
        _editContext = new EditContext(MseAuth);
        _messageStore = new ValidationMessageStore(_editContext);
        
        _editContext.OnFieldChanged += (object? sender, FieldChangedEventArgs args) =>
        {
            if (args.FieldIdentifier.Equals(_editContext.Field(nameof(MseAuth.MseCode))))
                _messageStore.Clear(_editContext.Field(nameof(MseAuth.MseCode)));
        };
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (_txtMseCode.Element != null)
                await _txtMseCode.Element.Value.FocusAsync();
        }
    }

    private void ButtonBackOnClick()
    {
        bool isValid = true;
        if (isValid)
        {
            OnValueChanged.InvokeAsync(SigninStepsEnum.FirstStep);
        }
    }

    private async Task ProcessStep()
    {
        if (!_editContext.Validate())
            return;

        if (MseAuth.MseCode!.Equals("ERBUC"))
        {
            await OnValueChanged.InvokeAsync(SigninStepsEnum.ThirdStep);
            return;
        }

        _messageStore.Clear();
        _messageStore.Add(_editContext.Field(nameof(MseAuth.MseCode)),
            "You have entered an invalid Code.");
        _editContext.NotifyValidationStateChanged();
    }
    
    private Func<SigninStepsEnum, Action> GoToStep => step => async () =>
    {
        if (OnValueChanged.HasDelegate)
            await OnValueChanged.InvokeAsync(step);
    };

  
}