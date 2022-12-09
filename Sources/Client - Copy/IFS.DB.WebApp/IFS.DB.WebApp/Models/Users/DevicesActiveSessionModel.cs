namespace IFS.DB.WebApp.Models.Users;

public record DevicesActiveSessionModel
{
    public int DeviceID { get; set; }
    public string DeviceName { get; set; }
    public string OperationSystem { get; set; }
    public string IPAddress { get; set; }
    public string Note { get; set; }
}
