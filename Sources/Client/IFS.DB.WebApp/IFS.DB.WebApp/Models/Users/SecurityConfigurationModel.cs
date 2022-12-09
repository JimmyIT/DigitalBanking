using IFS.DB.WebApp.Helpers.Enums;

namespace IFS.DB.WebApp.Models.Users;

public record SecurityConfigurationModel
{
    public SecurityFactorEnum AuthorizationType { get; set; }
}
