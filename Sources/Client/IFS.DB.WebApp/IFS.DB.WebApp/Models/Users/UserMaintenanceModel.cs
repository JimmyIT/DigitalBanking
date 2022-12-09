namespace IFS.DB.WebApp.Models.Users;

public record UserMaintenanceModel
{
    public List<UserInfoModel> UserInfos { get; set; }
    public int TotalRecords { get; set; }
}
