using FluentDate;
using FluentDateTime;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.Extensions;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.PayeeTemplate;
using IFS.DB.WebApp.Models.Payment;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class PaymentsHistoryComponent
{
    [Parameter] public EventCallback<CreatePaymentRequestModel> OnSetPaymentHistory { get; set; }
    [Parameter] public EventCallback<PayeeTemplateModel> OnSetPayeeTemplate { get; set; }

    private SpecificPeriodType _specificPeriodType = SpecificPeriodType.ThisWeek;

    private bool _isPaymentHistoryPanel = true;
    private bool _isPayeeTemplatesPanel = false;
    private string _active = "payments-history-header__item active";
    private string _notactive = "payments-history-header__item";
    private List<CreatePaymentRequestModel> _listLastPayment;
    private List<PayeeTemplateModel>? _listPayees;
    protected override async Task OnInitializedAsync()
    {
        _listPayees = FakeData.PayeeTemplates.OrderByDescending(x => x.Pinned).ThenByDescending(x => x.CreatedDate).ThenBy(x => x.HostReference).Take(5).ToList();
        await OnSelectedValue(_specificPeriodType);
    }

    private async Task ViewPaymentHistoryPanel()
    {
        _isPaymentHistoryPanel = true;
        _isPayeeTemplatesPanel = false;
    }

    private async Task ViewPayeeTemplatesPanel()
    {
        _isPaymentHistoryPanel = false;
        _isPayeeTemplatesPanel = true;
    }

    private async Task SetPaymentHistory(CreatePaymentRequestModel lastPayment)
    {        
        if (OnSetPaymentHistory.HasDelegate)
        {
            await OnSetPaymentHistory.InvokeAsync(lastPayment);
        }
        await ViewPaymentHistoryPanel();
    }

    private async Task SetPayeeTemplate(PayeeTemplateModel payeeTemplate)
    {        
        if (OnSetPayeeTemplate.HasDelegate)
        {
            await OnSetPayeeTemplate.InvokeAsync(payeeTemplate);
        }
        await ViewPayeeTemplatesPanel();
    }

    private async Task OnSelectedValue(SpecificPeriodType selectedValue)
    {
        _specificPeriodType = selectedValue;
        (DateTime from, DateTime to) = selectedValue.GetDateTimeRange();
        _listLastPayment = FakeData.LastPaymentTransactions.Where(x => x.PaymentDate >= from && x.PaymentDate <= to).Take(5).ToList();
    }

    private async Task SetFavouriteItem(PayeeTemplateModel changedPayeeModel)
    {
        FakeData.PayeeTemplates.ForEach(x =>
        {
            if (x.ID == changedPayeeModel.ID)
            {
                x.Pinned = changedPayeeModel.Pinned;
            }
        });
        _listPayees = FakeData.PayeeTemplates.OrderByDescending(x => x.Pinned).ThenByDescending(x => x.CreatedDate).ThenBy(x => x.iBankReference).Take(5).ToList();
    }

    private async Task DeleteItem(PayeeTemplateModel payeeModel)
    {
        FakeData.PayeeTemplates.Remove(payeeModel);
        _listPayees = FakeData.PayeeTemplates.OrderByDescending(x => x.Pinned).ThenByDescending(x => x.CreatedDate).ThenBy(x => x.iBankReference).Take(5).ToList();
    }
}