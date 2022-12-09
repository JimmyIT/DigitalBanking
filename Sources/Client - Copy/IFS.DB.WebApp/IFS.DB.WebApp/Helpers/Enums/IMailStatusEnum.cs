using System.ComponentModel;

namespace IFS.DB.WebApp.Helpers.Enums;

public enum IMailTabPageEnum
{
    [Description("All mails")]
    AllMails = 0,

    [Description("Inbox mails")]
    InboxMails = 1,

    [Description("Sent mails")]
    SentMails = 2,
}

public enum IMailStatusEnum
{
    [Description("New")]
    New = 0,
}

public enum IMailPriorityEnum
{
    [Description("High Priority")]
    High = 0,
}
