namespace IFS.DB.WebApp.Models.Account;

public class AccountModel
{
    public string AccountNumber { get; set; }
    public string AccountDescription { get; set; }
    public string ClientNumber { get; set; }
    public string CurrencyCode { get; set; }
    public decimal AvailableBalance { get; set; }
    public decimal CurrentBalance { get; set; }
    public decimal OverdraftLimit { get; set; }
    public decimal OverdraftAvailable { get; set; }
    public bool IsFavourite { get; set; }
}
