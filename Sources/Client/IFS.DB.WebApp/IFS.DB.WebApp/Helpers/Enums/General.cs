using System.ComponentModel;

namespace IFS.DB.WebApp.Helpers.Enums;

public enum PeriodType 
{
    [Description("Every second")]
    EverySecond = 1,
    [Description("Every minute")]
    EveryMinute,
    [Description("Every hour")]
    EveryHour,
    [Description("Every day")]
    EveryDay,
    [Description("Every week")]
    EveryWeek,
    [Description("Every quarter")]
    EveryQuarter,
    [Description("Every month")]
    EveryMonth,
    [Description("Every year")]
    EveryYear
}

public enum SpecificPeriodType
{
    [Description("This week")]
    ThisWeek = 1,
    [Description("Last week")]
    LastWeek,
    [Description("This month")]
    ThisMonth,
    [Description("Last month")]
    LastMonth
}

public enum TransactionType
{
    Payment = 1,
    Transfer
}
