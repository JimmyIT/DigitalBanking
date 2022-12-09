namespace IFS.DB.WebApp.Models.Customer;

public record CustomerMaintenanceModel
{
    public List<CustomerInfoModel> Customers { get; set; }
    public int TotalRecords { get; set; }
}
