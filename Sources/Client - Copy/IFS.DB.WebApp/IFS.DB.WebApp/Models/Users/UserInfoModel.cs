using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models.GroupMaintenance;

namespace IFS.DB.WebApp.Models.Users;

public record UserInfoModel
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string AvartaUrl { get; set; }
    public string PhoneNumberIDD { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string LastLoggedin { get; set; }
    public int? GroupID { get; set; }
    public GroupInfoModel? Group { get; set; }
    public NotificationConfigurationModel NotificationSettings { get; set; }
    public SecurityFactorEnum SecuritySetting { get; set; }
    public UserActionStatusEnum ActionStatus { get; set; }
    public string? LockReason { get; set; }
    public List<DevicesActiveSessionModel> DevicesActiveSessions { get; set; }
    public UserPreferenceModel? UserPreference { get; set; }
}
