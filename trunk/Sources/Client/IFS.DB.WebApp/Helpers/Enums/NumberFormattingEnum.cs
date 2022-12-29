namespace IFS.DB.WebApp.Helpers.Enums;

public static class NumberFormattingEnum
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/globalization/locale/number-formatting-in-dotnet-framework
    /// </summary>
    public enum FormatType
    {
        /// <summary>
        /// Currency
        /// </summary>
        C = 0,
        /// <summary>
        /// Number
        /// </summary>
        N = 1,
        /// <summary>
        /// Number with 1 decimal place
        /// </summary>
        N1 = 2,
        /// <summary>
        /// Number with 2 decimal place
        /// </summary>
        N2 = 3,
    }
}
