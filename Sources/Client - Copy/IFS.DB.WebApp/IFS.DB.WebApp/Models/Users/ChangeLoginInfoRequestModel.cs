using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.Users;

public record ChangeLoginInfoRequestModel
{
    public string CustomerID { get; set; }
    [Compare(nameof(CustomerID), ErrorMessage = "The CustomerID do not match")]
    public string ConfirmCustomerID { get; set; }
    [Required(ErrorMessage = "Required")]
    public string CurrentPassword { get; set; }
}
