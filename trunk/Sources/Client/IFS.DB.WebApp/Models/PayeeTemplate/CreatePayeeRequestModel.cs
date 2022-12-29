using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Resources;
using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.PayeeTemplate;

public record CreatePayeeRequestModel
{
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string TemplateRefernce { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public PaymentTypeEnum? PaymentType { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string AccountName { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string FromAccountNumber { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string ToAccountNumber { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string PaymentReference { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string DebitNarrative { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string SortCode { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string Currency { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string BankName { get; set; }
}
