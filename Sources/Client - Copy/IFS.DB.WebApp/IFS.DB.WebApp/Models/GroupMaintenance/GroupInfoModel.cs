using IFS.DB.WebApp.Models.Users;
using IFS.DB.WebApp.Resources;
using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.GroupMaintenance;
public record GroupInfoModel
{
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public int ID { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public string Name { get; set; }
    public string Description { get; set; }
    public List<UserInfoModel> GroupMembers { get; set; }
    public int TotalMembers { get; set; }
}
