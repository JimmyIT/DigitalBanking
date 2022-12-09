using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Helpers.CustomAnnotationAttributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class GreaterThanZero : ValidationAttribute
{
    public GreaterThanZero(string errorMessage) : base()
    {
        ErrorMessage = errorMessage;
    }

    public override bool IsValid(object value)
    {
        decimal i;
        return value != null && decimal.TryParse(value.ToString(), out i) && i > 0;
    }


    //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //{
    //    if(value == null)
    //        return new ValidationResult("The value should not be null or empty");

    //    ErrorMessage = ErrorMessageString;
    //    decimal i;

    //    if(!decimal.TryParse(value.ToString(), out i))
    //    {
    //        return new ValidationResult("The value should be a decimal number");
    //    }

    //    if(i <= 0)
    //    {
    //        return new ValidationResult(ErrorMessage);
    //    }

    //    return ValidationResult.Success;
    //}
}
