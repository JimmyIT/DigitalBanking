namespace IFS.DB.WebApp.Models.Transactions;

public class TransactionModel
{
    public string Reference { get; set; }
    public string Narrative { get; set; }
    public DateTime CreatedDate { get; set; }
    public decimal CreditAmount { get; set; }
    public decimal DebitAmount { get; set; }
    public decimal Balance { get; set; }
}
