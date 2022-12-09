using IFS.DB.WebApp.Helpers.Enums;

namespace IFS.DB.WebApp.Models.Customer;

public class SearchCustomerModel
{
    public string SearchString { get; set; }
    public List<CustomerInfoModel> Customers { get; set; }
    public List<CustomerTypeEnum> Types { get; set; }
}
