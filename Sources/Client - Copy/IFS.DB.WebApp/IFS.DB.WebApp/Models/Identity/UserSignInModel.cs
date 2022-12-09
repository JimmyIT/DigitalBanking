using IFS.DB.WebApp.Helpers.CustomAnnotationAttributes;
using IFS.DB.WebApp.Resources;
using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.Identity;

public class UserSignInModel
{
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    [IsExistCustomerID]
    public string CustomerID { get; set; }
    public string Password { get; set; }
    public string MSEAuthCode { get; set; }
    public string ClientNumber { get; set; }
    public string UserID { get; set; }
    public string InternalID { get; set; }
    public string SecurityCode { get; set; }
    public string Role { get; set; }
}
