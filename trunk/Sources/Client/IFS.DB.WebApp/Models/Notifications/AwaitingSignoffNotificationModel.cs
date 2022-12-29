using IFS.DB.WebApp.Helpers.Enums;

namespace IFS.DB.WebApp.Models.Notifications;

public class AwaitingSignoffNotificationModel
{
    public int UserID { get; set; }
    public string Name { get; set; }
    public string Time { get; set; }
    public string Description { get; set; }
    public string Note { get; set; }
    public string NewAuthorityCode { get; set; }
    public string LastAccessBy { get; set; }
    public UserActionStatusEnum Status { get; set; }
    public string UrlAvarta { get; set; }
}
