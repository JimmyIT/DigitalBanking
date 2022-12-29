using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models.Account;
using IFS.DB.WebApp.Models.Users;

namespace IFS.DB.WebApp.Models.Customer;

public record CustomerInfoModel
{
    public int ID { get; set; }
    public string CustomerID { get; set; }
    public string CustomerName { get; set; }
    public string Address { get; set; }
    public string AuthenticateCode { get; set; }
    public string Password { get; set; }
    public string SecurityCode { get; set; }
    public CustomerTypeEnum Type { get; set; }
    public bool IsHost { get; set; }
    public List<UserInfoModel> Users { get; set; }
    public List<AccountModel> Accounts { get; set; }
}
