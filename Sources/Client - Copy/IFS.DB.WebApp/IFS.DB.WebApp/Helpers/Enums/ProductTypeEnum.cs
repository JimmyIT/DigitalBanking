using System.ComponentModel;

namespace IFS.DB.WebApp.Helpers.Enums;

public enum ProductTypeEnum
{

    [Description("All product types")]
    All = 0,
    [Description("Domestic payments")]
    Domestic = 1,
    [Description("Transfers")]
    Transfer = 2,
    [Description("International payments")]
    SWIFT = 3,
    [Description("Batches")]
    Batches = 4
}
