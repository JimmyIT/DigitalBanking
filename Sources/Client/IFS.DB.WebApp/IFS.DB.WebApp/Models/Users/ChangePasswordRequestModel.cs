using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.Users;

public record ChangePasswordRequestModel
{
    public string CustomerID { get; set; }
    public string UserID { get; set; }
    [Required(ErrorMessage = "Required")]
    public string CurrentPassword { get; set; }
    [Required(ErrorMessage = "Required")]
    public string NewPassword { get; set; }
    [Required(ErrorMessage = "Required")]
    [Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match")]
    public string ConfirmNewPassword { get; set; }
}
