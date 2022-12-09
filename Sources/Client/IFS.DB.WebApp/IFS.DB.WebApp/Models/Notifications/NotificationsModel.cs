namespace IFS.DB.WebApp.Models.Notifications;

public class NotificationsModel
{
    public MSEAuthorityCodeNotificationModel? MSEAuthorityCodeNotification { get; set; }
    public List<AwaitingSignoffNotificationModel> AwaitingSignoffNotifications { get; set; }
}
