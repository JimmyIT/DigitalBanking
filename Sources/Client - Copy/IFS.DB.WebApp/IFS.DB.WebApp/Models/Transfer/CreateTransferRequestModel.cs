using IFS.DB.WebApp.Helpers.CustomAnnotationAttributes;
using IFS.DB.WebApp.Resources;
using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.Transfer;

public record CreateTransferRequestModel
{
    [CanNotEqualTo(nameof(CreditAccount), ErrorMessage = "Account From & Account To cannot be the same")]
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string? DebitAccount { get; set; }

    [CanNotEqualTo(nameof(DebitAccount), ErrorMessage = "Account From & Account To cannot be the same")]
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string? CreditAccount { get; set; }


    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    [Range(0.01, 999999999, ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "creditamount_error_msg")]
    public decimal? Amount { get; set; }


    [DataType(DataType.Date)]
    [PaymentDateTime(typeof(AppResources), "paymentdate_error_msg")]
    public DateTime TransferDate { get; set; } = DateTime.Now;


    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string? DebitNarrative { get; set; }


    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string? CreditNarrative { get; set; }

}
