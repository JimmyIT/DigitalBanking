using IFS.DB.WebApp.Helpers.Enums;

namespace IFS.DB.WebApp.Models.iMails;

public class IMailMessageModel
{
    public IMailMessageModel()
    {
        AnswerIMailMessages = new List<AnswerIMailMessageModel>();
    }

    public int MailID { get; set; }
    public int SenderID { get; set; }
    public int ReceiverID { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime? CreatedDate { get; set; }
    public IMailStatusEnum Status { get; set; }
    public IMailPriorityEnum Priority { get; set; }
    public List<AnswerIMailMessageModel> AnswerIMailMessages { get; set; }
}
