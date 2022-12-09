using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models.GroupMaintenance;

namespace IFS.DB.WebApp.Models.Users;

public class SearchUserModel
{
    public string  SearchString { get; set; }
    public List<GroupInfoModel> Groups { get; set; }
    public UserActionStatusEnum? ActionStatus { get; set; }
}
