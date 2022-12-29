using IFS.DB.WebApp.Helpers.Enums;

namespace IFS.DB.WebApp.Models.iMails;

public class AnswerIMailMessageModel
{
    public int AnswerID { get; set; }
    public int MailID { get; set; }
    public int SenderID { get; set; }
    public int ReceiverID { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime? CreatedDate { get; set; }
    public IMailStatusEnum Status { get; set; }
    public IMailPriorityEnum Priority { get; set; }
}
