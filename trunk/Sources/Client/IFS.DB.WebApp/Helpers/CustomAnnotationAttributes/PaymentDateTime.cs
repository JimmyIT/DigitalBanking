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

    //public override bool IsValid(object? value)
    //{
    //    DateTime inputtedDateTime = Convert.ToDateTime(value);

    //    if (inputtedDateTime.Date < DateTime.Today.Date)
    //    {
    //        return false;
    //    }

    //    return true;
    //}

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime inputtedDateTime = Convert.ToDateTime(value);

        if (inputtedDateTime.Date < DateTime.Today.Date)
        {
            return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
        }

        return ValidationResult.Success;
    }
}
