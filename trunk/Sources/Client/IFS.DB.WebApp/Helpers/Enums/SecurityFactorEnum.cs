using System.ComponentModel;

namespace IFS.DB.WebApp.Helpers.Enums;

public enum SecurityFactorEnum
{
    [Description("One factor authorization (only login and password)")]
    OneFactor = 0,
    [Description("Two factor authorization in any case")]
    TwoFactor = 1,
}

