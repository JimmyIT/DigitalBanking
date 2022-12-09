namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIMessageActionInfo
    {
        public struct Notification
        {
            public struct SendMail
            {
                public const string Code = "NTF01";
                public const string Description = "Send Mail";
            }

            public struct SendApplicationAcceptedEmail
            {
                public const string Code = "NTF02";
                public const string Description = "Send Application Accepted Email";
            }

            public struct SendSMS
            {
                public const string Code = "NTF03";
                public const string Description = "Send SMS";
            }

            public struct SendApplicationAcceptedSMS
            {
                public const string Code = "NTF04";
                public const string Description = "Send Application Accepted SMS";
            }
        }
    }
}
