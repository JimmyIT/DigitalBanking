using System.ComponentModel;

namespace IFS.DB.WebApp.Helpers.Enums;

public enum PaymentMethodEnum
{
    [Description("BACS")]
    BACS = 0,
    [Description("CHAPS")]
    CHAPS = 1,
    [Description("Faster")]
    Faster = 2    
}
