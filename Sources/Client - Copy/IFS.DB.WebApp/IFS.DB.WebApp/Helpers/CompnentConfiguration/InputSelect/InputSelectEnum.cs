using Humanizer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace IFS.DB.WebApp.Helpers.CompnentConfiguration.InputSelect;

public class InputSelectEnum<TEnum> : InputBase<TEnum>
{
    [Parameter] public string DefaultOption { get; set; }
    
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "select");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(4, "onchange", EventCallback.Factory.CreateBinder<string>(this, value => CurrentValueAsString = value, CurrentValueAsString, null));

        if (!string.IsNullOrEmpty(DefaultOption))
        {
            builder.OpenElement(5, "option");
            builder.AddAttribute(6, "value", "");
            builder.AddContent(7, DefaultOption);
            builder.CloseElement();
        }

        var enumType = GetEnumType();
        foreach (var value in Enum.GetValues(enumType))
        {
            builder.OpenElement(8, "option");
            builder.AddAttribute(9, "value", ((int)value).ToString());
            builder.AddContent(10, GetDisplayName(value));
            builder.CloseElement();
        }

        builder.CloseElement();
    }

    protected override bool TryParseValueFromString(string? value, out TEnum result, out string validationErrorMessage)
    {
   
        if (BindConverter.TryConvertTo(value, CultureInfo.CurrentCulture, out TEnum? parsedValue))
        {
            result = parsedValue;
            validationErrorMessage = null;
            return true;
        }

        result = default;
        validationErrorMessage = null;
        return true;
        
    }

    // Get the display text for an enum value:
    // - Use the DisplayAttribute if set on the enum member, so this support localization
    // - Fallback on Humanizer to decamelize the enum member name
    private string GetDisplayName(object value)
    {
        // Read the Display attribute name
        var member = value.GetType().GetMember(value.ToString())[0];
        var displayAttribute = member.GetCustomAttribute<DisplayAttribute>();
        if (displayAttribute != null)
            return displayAttribute.GetName();

        // Require the NuGet package Humanizer.Core
        // <PackageReference Include = "Humanizer.Core" Version = "2.8.26" />
        return value.ToString().Humanize();
    }

    // Get the actual enum type. It unwrap Nullable<T> if needed
    // MyEnum  => MyEnum
    // MyEnum? => MyEnum
    private Type GetEnumType()
    {
        var nullableType = Nullable.GetUnderlyingType(typeof(TEnum));
        if (nullableType != null)
            return nullableType;

        return typeof(TEnum);
    }
}
