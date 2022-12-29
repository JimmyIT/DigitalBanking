using IFS.DB.WebApp.Models.Payment;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class PayeeReferenceComponent
{
    [Parameter] public LastPaymentTransactionModel LastPaymentTransaction { get; set; }


}
