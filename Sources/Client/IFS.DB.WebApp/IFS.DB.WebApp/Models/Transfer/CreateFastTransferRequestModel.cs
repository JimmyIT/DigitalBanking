namespace IFS.DB.WebApp.Models.Transfer;

public class CreateFastTransferRequestModel
{
    public string FromAccount { get; set; }
    public string ToAccount { get; set; }
    public decimal Amount { get; set; }
}
