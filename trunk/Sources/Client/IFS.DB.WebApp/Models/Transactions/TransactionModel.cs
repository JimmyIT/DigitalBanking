using IFS.DB.WebApp.Helpers.Enums;

namespace IFS.DB.WebApp.Models.Transactions;

public record TransactionModel
{
    public string AccountNumber { get; set; }
    public string Reference { get; set; }
    public string Narrative { get; set; }
    public DateTime CreatedDate { get; set; }
    public decimal CreditAmount { get; set; }
    public decimal DebitAmount { get; set; }
    public decimal Balance { get; set; }
    public bool IsSettled { get; set; }
    public ProductTypeEnum? ProductType { get; set; }
    public TransactionTypeEnum? TransactionType { get; set; }
}
