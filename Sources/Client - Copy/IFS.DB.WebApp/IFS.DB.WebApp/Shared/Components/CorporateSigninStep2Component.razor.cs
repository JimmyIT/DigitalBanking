using System.ComponentModel.DataAnnotations;
using IFS.DB.WebApp.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using static IFS.DB.WebApp.Helpers.Enums.CorporateSignInEnum;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CorporateSigninStep2Component
{
    [Parameter] public EventCallback<SigninStepsEnum> OnValueChanged { get; set; }

    private readonly MSEAuth _model;
    private readonly EditContext _editContext;
    private readonly ValidationMessageStore _messageStore;
    private InputText _txtMseCode;

    public CorporateSigninStep2Component()
    {
        _model = new MSEAuth();
        _editContext = new EditContext(_model);
        _messageStore = new ValidationMessageStore(_editContext);
    }

    protected override void OnInitialized()
    {
        _editContext.OnFieldChanged += (object? sender, FieldChangedEventArgs args) =>
        {
            if (args.FieldIdentifier.Equals(_editContext.Field(nameof(_model.MseCode))))
                _messageStore.Clear(_editContext.Field(nameof(_model.MseCode)));
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

        if (_model.MseCode!.Equals("ERBUC"))
        {
            await OnValueChanged.InvokeAsync(SigninStepsEnum.ThirdStep);
            return;
        }

        _messageStore.Clear();
        _messageStore.Add(_editContext.Field(nameof(_model.MseCode)),
            "You have entered an invalid Code.");
        _editContext.NotifyValidationStateChanged();
    }
    
    private Func<SigninStepsEnum, Action> GoToStep => step => async () =>
    {
        if (OnValueChanged.HasDelegate)
            await OnValueChanged.InvokeAsync(step);
    };

    class MSEAuth
    {
        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
        public string? MseCode { get; set; }
    }
}