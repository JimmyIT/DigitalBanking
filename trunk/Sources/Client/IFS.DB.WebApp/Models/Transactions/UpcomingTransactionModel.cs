namespace IFS.DB.WebApp.Models.Transactions;

public class UpcomingTransactionModel
{
    public List<TransactionModel> UpcomingTransactions { get; set; }
    public int TotalRecords { get; set; }   
}

