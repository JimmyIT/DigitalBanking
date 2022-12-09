namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
        {
            public struct Notification
            {
                public const string SendMail = "send-mail";
                public const string SendApplicationAcceptedEmail = "send-applicattion-accepted-email";
                public const string SendSMS = "send-sms";
                public const string SendApplicationAcceptedSMS = "send-applicattion-accepted-sms";
            }
        }

        public partial struct EndPoint
        {
            public struct Notification
            {
                private const string This = DefaultRoute + "/" + Route.Controller.Notification + "/";
                public const string SendMail = This + Route.Notification.SendMail;
                public const string SendApplicationAcceptedEmail = This + Route.Notification.SendApplicationAcceptedEmail;
                public const string SendSMS = This + Route.Notification.SendSMS;
                public const string SendApplicationAcceptedSMS = This + Route.Notification.SendApplicationAcceptedSMS;
            }
        }
    }
}
