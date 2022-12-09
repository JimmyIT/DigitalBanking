namespace IFS.DB.WebApp.Models.Transactions;

public record RecentTransactionModel
{
    public List<TransactionModel> RecentTransactions { get; set; }
    public int TotalRecords { get; set; }
}

