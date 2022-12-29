using IFS.DB.WebApp.Helpers.CustomAnnotationAttributes;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.Payment;

public record CreatePayeeAndPaymentRequestModel
{
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string TemplateRefernce { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public PaymentTypeEnum? PaymentType { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string DebitAccount { get; set; }
    [RequiredBy("PaymentType", "Domestic", typeof(AppResources), "required")]
    public PaymentMethodEnum? PaymentMethod { get; set; }
    
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    [Range(0.01, 999999999, ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "creditamount_error_msg")]
    public decimal? CreditAmount { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string CurrencyCode { get; set; }
    [DataType(DataType.Date)]
    [PaymentDateTime(typeof(AppResources), "paymentdate_error_msg")]
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string PaymentReference { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string DebitNarrative { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string TypeOfDocument { get; set; }
    public string DocumentID { get; set; }
    [RequiredBy("PaymentType", "International", typeof(AppResources), "required")]
    public string BankName { get; set; }
    [RequiredBy("PaymentType", "Domestic", typeof(AppResources), "required")]
    public string CreditAccount { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string CreditAccountName { get; set; }
    [RequiredBy("PaymentType", "Domestic", typeof(AppResources), "required")]
    public string SortCode { get; set; }
    [RequiredBy("PaymentType", "International", typeof(AppResources), "required")]
    public string SwiftID { get; set; }

    [RequiredBy("PaymentType", "International", typeof(AppResources), "required")]
    public string IBAN { get; set; }
}
