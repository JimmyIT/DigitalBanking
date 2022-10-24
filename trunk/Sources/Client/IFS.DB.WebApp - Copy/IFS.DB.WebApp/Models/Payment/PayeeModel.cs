namespace IFS.DB.WebApp.Models.Payment;

public class PayeeModel
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string DebitAccount { get; set; }
    public string PaymentMethod { get; set; }
}
