using System.ComponentModel;

namespace IFS.DB.WebApp.Helpers.Enums;

public enum IMailTabPageEnum
{
    [Description("Unread mails")]
    UnreadMails = 0,

    [Description("Inbox mails")]
    InboxMails = 1,

    [Description("Sent mails")]
    SentMails = 2,
}

public enum IMailStatusEnum
{
    [Description("New")]
    New = 0,
    [Description("Read")]
    Read =1,
}

public enum IMailPriorityEnum
{
    [Description("High Priority")]
    High = 0,
}
