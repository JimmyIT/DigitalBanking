using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace IFS.DB.WebApp.Helpers.CustomAnnotationAttributes;

public class MobilePhone : ValidationAttribute
{
    private readonly string _phoneIDDProperty;
    private readonly string _regularExpressionPattern;

    public MobilePhone(string phoneIDDProperty, string regularExpressionPattern) :base()
    {
        _phoneIDDProperty = phoneIDDProperty;
        _regularExpressionPattern = regularExpressionPattern;
    }

    public MobilePhone(string regularExpressionPattern) : base()
    {
        _regularExpressionPattern = regularExpressionPattern;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        ErrorMessage = ErrorMessageString;
        string currentValue = value as string;

        if (!string.IsNullOrEmpty(_phoneIDDProperty))
        {
            var property = validationContext.ObjectType.GetProperty(_phoneIDDProperty);
            if (property == null)
                throw new ArgumentException("Property with this name not found");

            string phoneIDDValue = property.GetValue(validationContext.ObjectInstance) as string;
            currentValue = $"{phoneIDDValue?.ToString()}{currentValue}";
        }

        Regex regex = new Regex(_regularExpressionPattern, RegexOptions.IgnoreCase);
        if(regex.IsMatch(currentValue)) // (currentValue, _regularExpressionPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture).Success)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage);
    }
}
