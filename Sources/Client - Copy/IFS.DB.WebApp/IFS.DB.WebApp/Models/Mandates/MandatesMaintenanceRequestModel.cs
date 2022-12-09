using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Resources;
using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.Mandates;

public record MandatesMaintenanceRequestModel
{
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public decimal? MaximumAmount { get; set; }
    public List<MandatesItemModel>? MandatesItems { get; set; }
}


