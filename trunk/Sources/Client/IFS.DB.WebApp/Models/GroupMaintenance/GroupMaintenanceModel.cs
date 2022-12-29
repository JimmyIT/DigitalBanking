namespace IFS.DB.WebApp.Models.GroupMaintenance;
public record GroupMaintenanceModel
{
    public List<GroupInfoModel> Groups { get; set; }
    public int TotalRecords { get; set; }
}
