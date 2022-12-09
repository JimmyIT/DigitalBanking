namespace IFS.DB.WebApp.Models.Users;

public record ChangeNotificationConfigurationsRequestModel
{
    public bool InformTransactionsSMS { get; set; }
    public bool InformTransactionsEmail { get; set; }
    public bool InformTransactionsiMail { get; set; }

    public bool InformNewBankServicesSMS { get; set; }
    public bool InformNewBankServicesEmail { get; set; }
    public bool InformNewBankServicesiMail { get; set; }

    public bool InformMessagesFromManagerSMS { get; set; }
    public bool InformMessagesFromManagerEmail { get; set; }
    public bool InformMessagesFromManageriMail { get; set; }
}
