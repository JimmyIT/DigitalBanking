namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct Notification
            {
                public const string SendMail = "send-mail";
                public const string SendApplicationAcceptedEmail = "send-applicattion-accepted-email";
                public const string SendSMS = "send-sms";
                public const string SendApplicationAcceptedSMS = "send-applicattion-accepted-sms";
            }
        }

        public partial struct Response
        {
            public struct Notification
            {
                public const string MailSuccess = "Send Mail Success";
                public const string MailError = "Send Mail Error";

                public const string SMSSuccess = "Send SMS Success";
                public const string SMSError = "Send SMS Error";
            }
        }
    }
}
