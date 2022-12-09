using Blazored.Modal;
using IFS.DB.WebApp.Models.Payment;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class PaymentModalConfirmedComponent
{
    [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;
    [Parameter] public CreatePaymentRequestModel CreatePaymentModel { get; set; }

    protected override async Task OnInitializedAsync()
    {

    }

    private async Task Confirm()
    {
        await BlazoredModal.CloseAsync();
        _navigateManager.NavigateTo("/user/dashboard", forceLoad: false);
    }
    private async Task Close() => await BlazoredModal.CloseAsync();

}
