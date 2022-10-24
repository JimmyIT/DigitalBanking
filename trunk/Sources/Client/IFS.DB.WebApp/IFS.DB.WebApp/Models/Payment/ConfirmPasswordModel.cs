using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.Payment;

public class ConfirmPasswordModel
{
    [Required(ErrorMessage = "Required")]
    public string Password { get; set; }
}
