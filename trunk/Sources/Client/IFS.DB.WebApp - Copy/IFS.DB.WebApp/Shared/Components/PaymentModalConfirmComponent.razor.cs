using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models.Payment;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class PaymentModalConfirmComponent
{
    [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;
    [CascadingParameter] IModalService PaymentConfirmModalSvc { get; set; } = default!;
    [Parameter] public CreatePaymentRequestModel CreatePaymentModel { get; set; }

    private EditContext _confirmPasswordContext;
    private ValidationMessageStore _messageStore;
    private ConfirmPasswordModel _confirmPasswordModel = new();

    private bool _IsCorrectPassword = false;

    protected override async Task OnInitializedAsync()
    {
        _confirmPasswordContext = new EditContext(_confirmPasswordModel);
        _confirmPasswordContext.SetFieldCssClassProvider(new CustomPaymentConfirmFieldClassProvider());
        _messageStore = new ValidationMessageStore(_confirmPasswordContext);
        _confirmPasswordContext.OnFieldChanged += HandleFieldChanged;
    }

    private async Task Confirm()
    {
        bool isValid = _confirmPasswordContext.Validate();
        if (!isValid) return;

        var parameters = new ModalParameters().Add(nameof(PaymentModalConfirmedComponent.CreatePaymentModel), CreatePaymentModel);
        var options = new ModalOptions()
        {
            UseCustomLayout = true
        };

        PaymentConfirmModalSvc.Show<PaymentModalConfirmedComponent>("Payment was confirmed", parameters, options);        

        await BlazoredModal.CloseAsync();
    }

    private async Task Close() => await BlazoredModal.CloseAsync();

    private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
    {
        ResetValidation("Password");
        _messageStore.Clear();
        StateHasChanged();

        if (!string.IsNullOrEmpty(_confirmPasswordModel.Password) && !_confirmPasswordModel.Password.Equals("123456"))
        {
            _IsCorrectPassword = false;
            _messageStore.Add(_confirmPasswordContext.Field("Password"), "Incorrect password.");
            _confirmPasswordContext.NotifyValidationStateChanged();
            StateHasChanged();
        }
        else
        {
            _IsCorrectPassword = true;
        }

        bool isValid = _confirmPasswordContext.Validate();
        if (!isValid) return;

        StateHasChanged();
    }

    protected void ResetValidation(string field)
    {
        _messageStore.Clear(_confirmPasswordContext.Field(field));
        _confirmPasswordContext.NotifyValidationStateChanged();
    }
}
