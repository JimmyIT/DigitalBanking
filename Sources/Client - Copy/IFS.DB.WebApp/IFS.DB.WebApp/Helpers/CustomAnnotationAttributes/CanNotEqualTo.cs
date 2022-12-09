using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Helpers.CustomAnnotationAttributes;

public class CanNotEqualTo : ValidationAttribute
{
    private readonly string _comparisonPropertyName;
    public CanNotEqualTo(string comparisonPropertyName) :base()
    {
        _comparisonPropertyName = comparisonPropertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        ErrorMessage = ErrorMessageString;
        var currentValue = value;

        var property = validationContext.ObjectType.GetProperty(_comparisonPropertyName);

        if (property == null)
            throw new ArgumentException("Property with this name not found");
        
        var comparisonValue = property.GetValue(validationContext.ObjectInstance);
        if (currentValue.ToString().Equals(comparisonValue))
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}
