using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.PayeeTemplate;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class NewPayeeModalComponent
{
    [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;
    [Parameter] public bool IsReturnData { get; set; } = false;

    private EditContext _createPayeeContext;
    private ValidationMessageStore _messageStore;
    private CreatePayeeRequestModel _createPayeeModel = new();

    protected override async Task OnInitializedAsync()
    {
        _createPayeeContext = new EditContext(_createPayeeModel);
        _createPayeeContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _messageStore = new ValidationMessageStore(_createPayeeContext);
    }

    private async Task Close() => await BlazoredModal.CloseAsync(ModalResult.Cancel());

    private async void CreatePayee()
    {
        FakeData.PayeeTemplates.Add(new PayeeTemplateModel()
        {
            iBankReference = _createPayeeModel.TemplateRefernce,
            HostReference = _createPayeeModel.PaymentReference,
            DebitAccount = _createPayeeModel.FromAccountNumber,
            PaymentTemplateType = _createPayeeModel.PaymentType.GetValueOrDefault(),
            CreditCurrency = _createPayeeModel.Currency,
            CreatedDate = DateTime.Now,
            BankName = _createPayeeModel.BankName
        });
        if(IsReturnData)
        { 
            await BlazoredModal.CloseAsync(ModalResult.Ok<CreatePayeeRequestModel>(_createPayeeModel));
        }
        else
        {
            await BlazoredModal.CloseAsync();
        }
    }

    private void InvalidSubmit()
    {

    }

    private async Task OnPaymentType_OnChanged(PaymentTypeEnum? value) => _createPayeeModel.PaymentType = value;
}
