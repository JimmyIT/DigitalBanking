using IFS.DB.WebApp.Helpers.Enums;

namespace IFS.DB.WebApp.Models.Transactions;

public class SearchTransactionModel
{
    public string SearchString { get; set; }
    public string AccountNumber { get; set; }
    public ProductTypeEnum? ProductType { get; set; } = ProductTypeEnum.All;
    public TransactionTypeEnum? TransactionType { get; set; } = TransactionTypeEnum.All;
    public decimal? FromAmount { get; set; }
    public decimal? ToAmount { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
