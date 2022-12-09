using System.ComponentModel;

namespace IFS.DB.WebApp.Helpers.Enums;

public enum CustomerTypeEnum
{
    [Description("All customer types")]
    All = 0,
    [Description("MSE")]
    MSE = 1,
    [Description("SSE")]
    SSE = 2,
}
