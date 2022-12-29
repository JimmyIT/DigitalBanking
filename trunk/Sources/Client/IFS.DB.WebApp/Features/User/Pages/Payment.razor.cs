using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.PayeeTemplate;
using IFS.DB.WebApp.Models.Payment;
using IFS.DB.WebApp.Shared.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Features.User.Pages;

public partial class Payment : IDisposable
{    
    [CascadingParameter] IModalService PaymentModalSvc { get; set; } = default!;

    private EditContext _createPaymentContext;
    private ValidationMessageStore _messageStore;
    private CreatePaymentRequestModel _createPaymentModel = new();
    private CreatePayeeAndPaymentRequestModel _createPayeeAndPaymentModel = new();

    private IReadOnlyCollection<PayeeTemplateModel>? _listPayees;
    private PayeeTemplateModel _selectedPayee = new();

    private bool _isInputPayee = false;
    private bool isPayTemplatesChanged = false;

    protected override async Task OnInitializedAsync()
    {
        _listPayees = FakeData.PayeeTemplates;

        _createPaymentContext = new EditContext(_createPaymentModel);
        _createPaymentContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _messageStore = new ValidationMessageStore(_createPaymentContext);
        _createPaymentContext.OnFieldChanged += HandleFieldChanged;

        if (_appStore.PayeeTemplateStore is not null)
        {
            _selectedPayee = _appStore.PayeeTemplateStore;
            OnSelectedPayeeChanged(_selectedPayee.HostReference);
        }
    }

    private void InvalidSubmit()
    {
       
    }

    private void CreatePayment()
    {
        bool isValid = _createPaymentContext.Validate();
        if (!isValid) return;

        var options = new ModalOptions()
        {
            UseCustomLayout = true
        };
        var parameters = new ModalParameters();
        if (_isInputPayee)
        {
            parameters
                .Add(nameof(PaymentModalConfirmComponent.CreatePayeeAndPaymentModel), _createPayeeAndPaymentModel);
        }
        else
        {
            parameters.Add(nameof(PaymentModalConfirmComponent.CreatePaymentModel), _createPaymentModel);
        }
        parameters.Add(nameof(PaymentModalConfirmComponent.IsInputPayee), _isInputPayee);

        PaymentModalSvc.Show<PaymentModalConfirmComponent>("Confirm Payment", parameters, options);
    }

    private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
    {
        //string result = string.Format(System.Globalization.CultureInfo.GetCultureInfo("de-DE"), "{0:000,000.00}", 202667.4);

        //ServerValidation();
        //StateHasChanged();
    }

    private void OnSelectedPayeeChanged(string value)
    {
        string selectedValue = value;
        _selectedPayee = _listPayees.FirstOrDefault(x => x.HostReference == selectedValue);
        if(_selectedPayee != null)
        {
            _createPaymentModel.TemplateRefernce = _selectedPayee?.HostReference;
            _createPaymentModel.PaymentType = _selectedPayee.PaymentTemplateType;
            _createPaymentModel.DebitAccount = _selectedPayee.DebitAccount;
            _createPaymentModel.PaymentMethod = _selectedPayee.PaymentMethod;
            _createPaymentModel.CurrencyCode = _selectedPayee.CreditCurrency;
            StateHasChanged();
        }
        else
        {
            _createPaymentModel.TemplateRefernce = string.Empty;
            _createPaymentModel.PaymentType = null;
            _createPaymentModel.DebitAccount = null;
            _createPaymentModel.PaymentMethod = null;
            _createPaymentModel.CurrencyCode = null;
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
        if (_selectedPayee.PaymentTemplateType != PaymentTypeEnum.International)
        {
            if (!_createPaymentModel.PaymentMethod.HasValue)
            {
                _messageStore.Add(_createPaymentContext.Field("PaymentMethod"), L["required"].ToString());
                _createPaymentContext.NotifyValidationStateChanged();
                StateHasChanged();
            }
        }

        //bool isValid = _createPaymentContext.Validate();
        //if (!isValid) return;
    }

    protected void ResetValidation(string field)
    {
        _messageStore.Clear(_createPaymentContext.Field(field));
        _createPaymentContext.NotifyValidationStateChanged();
    }

    private async Task OnSelectedChange(PayeeTemplateModel selectedPayee) => _selectedPayee = selectedPayee;
    private async Task OnSelectedPaymentHistory(CreatePaymentRequestModel model)
    {
        if (_isInputPayee)
        {
            EnableInputPayeeMode(!_isInputPayee);
        }
        _createPaymentModel = model with { };
        _createPaymentContext = new EditContext(_createPaymentModel);
        _createPaymentContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _messageStore = new ValidationMessageStore(_createPaymentContext);
        _createPaymentContext.OnFieldChanged += HandleFieldChanged;

        OnSelectedPayeeChanged(_createPaymentModel.TemplateRefernce);
    }

    private async Task OnSelectedPayeeTemplate(PayeeTemplateModel templateModel)
    {
        if(_isInputPayee)
        {
            EnableInputPayeeMode(!_isInputPayee);
        }
        await OnSelectedChange(templateModel);

        _createPaymentModel = new()
        {
            TemplateRefernce = _selectedPayee.HostReference
        };
        _createPaymentContext = new EditContext(_createPaymentModel);
        _createPaymentContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _messageStore = new ValidationMessageStore(_createPaymentContext);
        _createPaymentContext.OnFieldChanged += HandleFieldChanged;

        OnSelectedPayeeChanged(_createPaymentModel.TemplateRefernce);
    }

    private async Task EnableInputPayeeMode(bool isInputPayee)
    {
        _isInputPayee = isInputPayee;

        if(_isInputPayee)
        {
            _createPaymentModel = null;
            if (_createPayeeAndPaymentModel == null)
            {
                _createPayeeAndPaymentModel = new CreatePayeeAndPaymentRequestModel();
            }
            _createPaymentContext = new EditContext(_createPayeeAndPaymentModel);
        }
        else
        {
            _createPayeeAndPaymentModel = null;
            if (_createPaymentModel == null)
            {
                _createPaymentModel = new CreatePaymentRequestModel();
            }
            _createPaymentContext = new EditContext(_createPaymentContext);
        }

        _createPaymentContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _messageStore = new ValidationMessageStore(_createPaymentContext);
        _createPaymentContext.OnFieldChanged += HandleFieldChanged;
    }

    private async void ShowModalCreatePayee()
    {
        ModalParameters parameters = new ModalParameters()
            .Add(nameof(NewPayeeModalComponent.IsReturnData), true);
        var options = new ModalOptions()
        {
            UseCustomLayout = true
        };
        var modalResult = PaymentModalSvc.Show<NewPayeeModalComponent>("Create new Payee", parameters, options);
        var result = await modalResult.Result;
        if (result.Confirmed)
        {
            _listPayees = FakeData.PayeeTemplates;
            isPayTemplatesChanged = !isPayTemplatesChanged;
            StateHasChanged();

            OnSelectedPayeeChanged(((CreatePayeeRequestModel)result.Data).PaymentReference);
        }
    }

    private async Task OnPaymentType_OnChanged(PaymentTypeEnum? value)
    {
        if(_isInputPayee)
        {
            _createPayeeAndPaymentModel.PaymentType = value;
        }
        else
        {
            _createPaymentModel.PaymentType = value;
        }
    }

    public void Dispose()
    {
        _createPaymentContext.OnFieldChanged -= HandleFieldChanged;
    }
}
