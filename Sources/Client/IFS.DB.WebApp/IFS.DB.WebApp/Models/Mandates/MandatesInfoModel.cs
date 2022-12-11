using IFS.DB.WebApp.Helpers.CustomAnnotationAttributes;
using IFS.DB.WebApp.Resources;
using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.Mandates;

public record MandatesInfoModel
{
    public Guid MandatesID { get; set; }

    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    [GreaterThanZero("Maximum amount must be greater than 0")]
    public decimal? Amount { get; set; }
}

public record MandatesItemInfoModel
{
    public Guid ItemID { get; set; }

    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    [GreaterThanZero("Maximum amount must be greater than 0")]
    public decimal? Amount { get; set; }
}