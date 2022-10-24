using IFS.DB.WebApp.Helpers.CustomAnnotationAttributes;
using IFS.DB.WebApp.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.Payment;

public class CreatePaymentRequestModel
{
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string TemplateRefernce { get; set; }
    public string PaymentType { get; set; }
    public string DebitAccount { get; set; }

    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string PaymentMethod { get; set; }

    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string PaymentFrom { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    [Range(0.01, 999999999, ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "creditamount_error_msg")]
    public decimal CreditAmount { get; set; }
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
}
