using IFS.DB.WebApp.Helpers.CustomAnnotationAttributes;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Resources;
using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.Users;

public record UserCreationRequestModel
{
    private readonly Random _random = new Random();
    public UserCreationRequestModel()
    {
        UserId = _random.Next(0, 2147483647);
    }

    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public int UserId { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string UserName { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
    public string EmailAddress { get; set; }
    public string PhoneNumberIDD { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    [MobilePhone("PhoneNumberIDD", "^\\+?[1-9][0-9]{7,14}$", ErrorMessage = "Please enter valid phone number")]
    public string PhoneNumber { get; set; }
    public string Language { get; set; }
    public int? GroupID { get; set; }
    public UserActionStatusEnum? ActionStatus { get; set; }
    public string? LockReason { get; set; }
    public UserPreferenceModel UserPreference { get; set; }
}
