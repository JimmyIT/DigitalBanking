using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace IFS.DB.WebApp.Helpers.Extensions;

public static class UiDisplayExtension
{
    public static string ToNumberFormat(this decimal self, int numberPrecision = 2, bool emptyIfZero = false)
    {
        if (self.Equals(decimal.Zero) && emptyIfZero)
            return string.Empty;

        NumberFormatInfo formatInfo = CultureInfo.CurrentCulture.NumberFormat;
        return self.ToString($"N{numberPrecision}", formatInfo);
    }

    public static string ToNumberFormat(this decimal? self, int numberPrecision = 2, bool emptyIfZero = false)
        => self is null ? string.Empty : self.Value.ToNumberFormat(numberPrecision, emptyIfZero);

    public static string ToFullDateTimeFormat(this DateTime? dateTime)
        => dateTime is null ? string.Empty : $"{dateTime.Value:dd MMM yyyy} at {dateTime.Value:hh:mm}";
    
    //for the sake of demo, haven't tested yet
    public static string ToTimeAgo(this DateTime past)
    {
        if (past > DateTime.Now)
        {
            // ???
        }
        
        DateTime now = DateTime.Now;

        TimeSpan spanTime = now.Subtract(past);
        
        var timeBuilder = new StringBuilder();
    
        if (spanTime.Days > 0 )
            timeBuilder.Append($"{spanTime.Days}d ");
    
        if (spanTime.Hours > 0 )
            timeBuilder.Append($"{spanTime.Hours}h ");

        if (spanTime.Minutes > 0)
            timeBuilder.Append($"{spanTime.Minutes}m ");
        else
            timeBuilder.Append("1m");

        return timeBuilder.ToString();
    }

    public static string ToDescription<TEnum>(this TEnum enumValue) where TEnum : struct
    {
        var field = enumValue.GetType().GetField(enumValue.ToString());
        if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
        {
            return attribute.Description;
        }

        throw new ArgumentException("Item not found.", nameof(enumValue));
    }
}