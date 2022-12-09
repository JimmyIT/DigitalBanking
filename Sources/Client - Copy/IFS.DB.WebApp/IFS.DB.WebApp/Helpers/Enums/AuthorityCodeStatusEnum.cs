using System.ComponentModel;

namespace IFS.DB.WebApp.Helpers.Enums;

public enum AuthorityCodeStatusEnum
{
    [Description("Awaiting Sign-off")]
    AwaitingSignoff = 0,
    [Description("Confirmed")]
    Confirmed = 1,
    [Description("Rejected")]
    Rejected = 2,
}
