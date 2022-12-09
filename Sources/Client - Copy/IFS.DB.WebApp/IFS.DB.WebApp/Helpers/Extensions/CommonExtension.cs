using FluentDate;
using FluentDateTime;
using IFS.DB.WebApp.Helpers.Enums;

namespace IFS.DB.WebApp.Helpers.Extensions;

public static class CommonExtension
{
    public static (DateTime From, DateTime To) GetDateTimeRange(this SpecificPeriodType periodType)
    {
        DateTime fromDate = DateTime.Now;
        DateTime toDate = DateTime.Now;
        switch (periodType)
        {
            case SpecificPeriodType.ThisWeek:
            {
                toDate = DateTime.Now;
                fromDate = DateTime.Today.AddDays(DayOfWeek.Monday - toDate.DayOfWeek);
                break;
            }
            case SpecificPeriodType.LastWeek:
            {
                DateTime monday = 1.Weeks().Ago();
                DateTime sunday = monday.Next(DayOfWeek.Sunday);

                toDate = new DateTime(sunday.Year, sunday.Month, sunday.Day, 23, 59, 59, 999);
                fromDate = new DateTime(monday.Year, monday.Month, monday.Day);
                break;
            }
            case SpecificPeriodType.ThisMonth:
            {
                fromDate = new DateTime(fromDate.Year, fromDate.Month, 1);
                break;
            }
            case SpecificPeriodType.LastMonth:
            {
                toDate = new DateTime(toDate.Year, toDate.Month, 1).AddDays(-1);
                fromDate = new DateTime(fromDate.Year, fromDate.Month, 1).AddMonths(-1);
                break;
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(periodType), periodType, null);
        }

        return (fromDate, toDate);
    }
}