using IFS.DB.WebApp.Helpers.CustomAnnotationAttributes;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Resources;
using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.Mandates;

public record MandatesMaintenanceRequestModel
{
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    [GreaterThanZero("Maximum amount must be greater than 0")]
    public decimal? MaximumAmount { get; set; }

   // [ValidateComplexType]
    public List<MandatesItemModel>? MandatesItems { get; set; }
}


