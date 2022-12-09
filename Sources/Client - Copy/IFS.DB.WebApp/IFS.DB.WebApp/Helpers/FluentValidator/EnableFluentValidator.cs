using System.Reflection;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;

namespace IFS.DB.WebApp.Helpers.FluentValidator;

/// <summary>
/// reference: https://www.syncfusion.com/blogs/post/create-edit-forms-with-fluentvalidation-and-syncfusion-blazor-components.aspx
/// </summary>
public class EnableFluentValidator<TValidator> : ComponentBase where TValidator : IValidator
{
    [Inject] private IServiceProvider ServiceProvider { get; set; } = default!;

    private static readonly char[] Separators = { '.', '[' };
    private TValidator _validator = default!;

    [CascadingParameter] EditContext EditContext { get; set; } = default!;
    
    protected override void OnInitialized()
    {
        _validator = ServiceProvider.GetService<TValidator>() ??
                     throw new ArgumentNullException($"Can't resolve type {typeof(TValidator)}");

        _ = EditContext ?? throw new ArgumentNullException(nameof(EditContext));

        var messages = new ValidationMessageStore(EditContext);

        EditContext.OnFieldChanged += (sender, args)
            => ValidateModel((EditContext)sender!, messages, args);

        EditContext.OnValidationRequested += (sender, _)
            => ValidateModel((EditContext)sender!, messages);
    }

    private void ValidateModel(object? sender, ValidationMessageStore messages, FieldChangedEventArgs? args = null)
    {
        ValidationContext<object> validateContext = new(EditContext.Model);
        ValidationResult? validateResul = _validator.Validate(validateContext);

        //validate just one field
        if (args is { })
        { 
            messages.Clear(args.FieldIdentifier);
            foreach (ValidationFailure? error in validateResul.Errors)
            {
                if (error.PropertyName.Equals(args.FieldIdentifier.FieldName))
                {
                    messages.Add(args.FieldIdentifier, error.ErrorMessage);
                }
            }
            return;
        }
        
        messages.Clear();

        foreach (ValidationFailure? error in validateResul.Errors)
        {
            FieldIdentifier fieldIdentifier = ToFieldIdentifier(EditContext, error.PropertyName);
            messages.Add(fieldIdentifier, error.ErrorMessage);
        }
    }

    private static FieldIdentifier ToFieldIdentifier(EditContext editContext, string propertyPath)
    {
        var obj = editContext.Model;

        while (true)
        {
            var nextTokenEnd = propertyPath.IndexOfAny(Separators);
            if (nextTokenEnd < 0)
            {
                return new FieldIdentifier(obj, propertyPath);
            }

            var nextToken = propertyPath[..nextTokenEnd];
            propertyPath = propertyPath[(nextTokenEnd + 1)..];

            object? newObj;
            if (nextToken.EndsWith("]"))
            {
                // It's an indexer
                nextToken = nextToken[..^1];
                PropertyInfo? prop = obj.GetType().GetProperty("Item");
                Type? indexerType = prop?.GetIndexParameters()[0].ParameterType;
                if (indexerType != null)
                {
                    var indexerValue = Convert.ChangeType(nextToken, indexerType);
                    newObj = prop?.GetValue(obj, new object[] { indexerValue });
                }
                else
                {
                    newObj = null;
                }
            }
            else
            {
                // It's a regular property
                PropertyInfo? prop = obj.GetType().GetProperty(nextToken);
                if (prop == null)
                {
                    throw new InvalidOperationException(
                        $"Could not find property named {nextToken} on object of type {obj.GetType().FullName}.");
                }

                newObj = prop.GetValue(obj);
            }

            if (newObj == null)
            {
                return new FieldIdentifier(obj, nextToken);
            }

            obj = newObj;
        }
    }
}