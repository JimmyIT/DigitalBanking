using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Resources;
using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.Users;

public record UserPreferenceModel
{
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public UserAccessLevelEnum? AccessLevel { get; set; }
    public List<UsePaymentPreferenceEnum> UsePaymentPreferences { get; set; }
    public List<UseTransferPreferenceEnum> UseTransferPreferences { get; set; }
    public List<CustomerAccessEnum> CustomerAccesses { get; set; }
}
