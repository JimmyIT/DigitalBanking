using IFS.DB.WebApp.Models.Payment;
using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Helpers.CustomAnnotationAttributes;

public class PaymentDateTime : ValidationAttribute
{
    public PaymentDateTime(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public PaymentDateTime(Type? errorMessageResourceType, string errorResourceName)
    {
        ErrorMessageResourceType = errorMessageResourceType;
        ErrorMessageResourceName = errorResourceName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime inputtedDateTime = Convert.ToDateTime(value);

        if (inputtedDateTime.Date < DateTime.Today.Date)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}
