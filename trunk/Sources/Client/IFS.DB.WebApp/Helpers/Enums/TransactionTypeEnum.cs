using System.ComponentModel;

namespace IFS.DB.WebApp.Helpers.Enums;

public enum TransactionTypeEnum
{
    [Description("All transaction types")]
    All = 0,
    [Description("Income")]
    Income = 1,
    [Description("Outcome")]
    Outcome = 2,
}
