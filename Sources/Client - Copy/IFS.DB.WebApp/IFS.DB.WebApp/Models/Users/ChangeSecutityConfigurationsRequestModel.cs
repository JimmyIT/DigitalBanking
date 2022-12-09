using IFS.DB.WebApp.Helpers.Enums;

namespace IFS.DB.WebApp.Models.Users;

public record ChangeSecutityConfigurationsRequestModel
{
    public ChangeSecutityConfigurationsRequestModel(List<DevicesActiveSessionModel> devicesActiveSessions, SecurityFactorEnum securitySetting)
    {
        DevicesActiveSessions = devicesActiveSessions;
        SecuritySetting = securitySetting;
    }

    public SecurityFactorEnum SecuritySetting { get; set; }
    public List<DevicesActiveSessionModel> DevicesActiveSessions { get; set; }
}
