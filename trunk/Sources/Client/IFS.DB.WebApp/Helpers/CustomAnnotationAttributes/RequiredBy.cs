using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Helpers.CustomAnnotationAttributes;

public class RequiredBy : ValidationAttribute
{
    public RequiredBy(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    private string _propertyName = string.Empty;
    private string _propertyValue = string.Empty;
    public RequiredBy(string PropertyName, string PropertyValue, Type? errorMessageResourceType, string errorResourceName)
    {
        _propertyName = PropertyName;
        _propertyValue = PropertyValue;

        ErrorMessageResourceType = errorMessageResourceType;
        ErrorMessageResourceName = errorResourceName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string currentValueAsString = value as string;

        var property = validationContext.ObjectType.GetProperty(_propertyName);
        if (property == null)
            throw new ArgumentException($"Property with the name {_propertyName} not found");

        var currentPropertyValue = property.GetValue(validationContext.ObjectInstance);
        if(_propertyValue == currentPropertyValue?.ToString())
        {
            if(value == null)
            {
                return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
            }
        }

        return ValidationResult.Success;
    }
}
