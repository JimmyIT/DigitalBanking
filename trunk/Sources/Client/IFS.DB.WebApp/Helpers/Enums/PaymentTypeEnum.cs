using System.ComponentModel;

namespace IFS.DB.WebApp.Helpers.Enums;

public enum PaymentTypeEnum
{
    [Description("Domestic")]
    Domestic = 1,
    [Description("International")]
    International = 2,
}
