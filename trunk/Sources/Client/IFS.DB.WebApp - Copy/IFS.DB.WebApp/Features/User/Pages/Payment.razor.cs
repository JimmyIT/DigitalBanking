using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models.Payment;
using IFS.DB.WebApp.Shared.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;

namespace IFS.DB.WebApp.Features.User.Pages;

public partial class Payment : IDisposable
{    
    [CascadingParameter] IModalService PaymentModalSvc { get; set; } = default!;

    private EditContext _createPaymentContext;
    private ValidationMessageStore _messageStore;
    private CreatePaymentRequestModel _createPaymentModel = new();

    private PayeeModel[]? _listPayees;
    private AccountModel[]? _listAccounts;
    private PaymentMethodsModel[]? _listPaymentMethods;
    private PayeeModel _selectedPayee = new();

    protected override async Task OnInitializedAsync()
    {
        _listPayees = await _httpClient.GetFromJsonAsync<PayeeModel[]>("sample-data/payees.json");
        _listAccounts = await _httpClient.GetFromJsonAsync<AccountModel[]>("sample-data/accounts.json");
        _listPaymentMethods = await _httpClient.GetFromJsonAsync<PaymentMethodsModel[]>("sample-data/paymentmethods.json");

        _createPaymentContext = new EditContext(_createPaymentModel);
        _createPaymentContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _messageStore = new ValidationMessageStore(_createPaymentContext);
        _createPaymentContext.OnFieldChanged += HandleFieldChanged;
    }
    private void InvalidSubmit()
    {
       
    }

    private void CreatePayment()
    {
        bool isValid = _createPaymentContext.Validate();
        if (!isValid) return;

        var parameters = new ModalParameters().Add(nameof(PaymentModalConfirmComponent.CreatePaymentModel), _createPaymentModel);
        var options = new ModalOptions()
        {
            UseCustomLayout = true
        };
        PaymentModalSvc.Show<PaymentModalConfirmComponent>("Confirm Payment", parameters, options);
    }

    private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
    {
        string result = string.Format(System.Globalization.CultureInfo.GetCultureInfo("de-DE"), "{0:000,000.00}", 202667.4);

        ServerValidation();
        StateHasChanged();
    }

    private void OnSelectedPayeeChanged(string value)
    {
        string selectedValue = value;
        _selectedPayee = _listPayees.FirstOrDefault(x => x.Name == selectedValue);
        if(_selectedPayee != null)
        {
            _createPaymentModel.TemplateRefernce = _selectedPayee?.Name;
            _createPaymentModel.PaymentType = _selectedPayee?.Type;
        }
        else
        {
            _createPaymentModel.TemplateRefernce = string.Empty;
            _createPaymentModel.PaymentType = string.Empty;
            _selectedPayee = new();
        }
    }

    private void ServerValidation()
    {
        ResetValidation("CreditAmount");
        _messageStore.Clear();
        StateHasChanged();
        if (_createPaymentModel.CreditAmount > 9999)
        {
            _messageStore.Add(_createPaymentContext.Field("CreditAmount"), "Credit amount could be greater than 9999");
            _createPaymentContext.NotifyValidationStateChanged();
            StateHasChanged(); 
        }

        bool isValid = _createPaymentContext.Validate();
        if (!isValid) return;
    }

    protected void ResetValidation(string field)
    {
        _messageStore.Clear(_createPaymentContext.Field(field));
        _createPaymentContext.NotifyValidationStateChanged();
    }

    public void Dispose()
    {
        _createPaymentContext.OnFieldChanged -= HandleFieldChanged;
    }
}
