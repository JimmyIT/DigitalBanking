using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.Extensions;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Notifications;

namespace IFS.DB.WebApp.Shared.Components;

public partial class AdminDashboardNotificationComponent
{
    private NotificationsModel Notifications;
    protected override async Task OnInitializedAsync()
    {
        if (FakeData.MseAuthorityCode is { })
        {
            FakeData.Notifications.MSEAuthorityCodeNotification = new MSEAuthorityCodeNotificationModel
            {
                Name = "MSE Authority Code",
                Description =
                    "Administrator 1  has requested a change to the MSE Authority Code which requires your signature to make it active.",
                LastAccessBy = FakeData.MseAuthorityCode.LastAccessOn.ToFullDateTimeFormat(),
                NewAuthorityCode = FakeData.MseAuthorityCode.AuthorityCode ?? string.Empty,
                Note = string.Empty,
                Status = AuthorityCodeStatusEnum.AwaitingSignoff,
                Time = FakeData.MseAuthorityCode.LastAccessOn?.ToTimeAgo() ?? string.Empty,
                Icon = "/img/admin/authorityCodeIcon.svg"
            };
        }
        else
        {
            FakeData.Notifications.MSEAuthorityCodeNotification = null;
        }
        
        Notifications = FakeData.Notifications;
    }
}
