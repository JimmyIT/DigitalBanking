using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Helpers.CustomAnnotationAttributes;

public class IsExistCustomerID : ValidationAttribute
{
    public IsExistCustomerID() : base()
    { }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        /// TODO: CALL API to check the ID is exist.
        return ValidationResult.Success;
    }
}
