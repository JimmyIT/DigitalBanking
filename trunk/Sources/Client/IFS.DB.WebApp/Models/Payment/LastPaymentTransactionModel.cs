using IFS.DB.WebApp.Helpers.Enums;

namespace IFS.DB.WebApp.Models.Payment;

public class LastPaymentTransactionModel
{
    public string AccountNumber { get; set; }
    public string PayeeTemplateReference { get; set; }
    public DateTime CreatedDate { get; set; }
    public PaymentMethodEnum PaymentMethod { get; set; }
    public PaymentTypeEnum PaymentType { get; set; }
    public decimal CreditAmount { get; set; }
}
