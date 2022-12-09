namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIMessageActionInfo
    {
        public struct Customer
        {
            public struct CreateSSE
            {
                public const string Code = "CUS01";
                public const string Description = "Create SSE Customer";
            }

            public struct UpdateSSE
            {
                public const string Code = "CUS02";
                public const string Description = "Update SSE Customer";
            }

            public struct CreateMSE
            {
                public const string Code = "CUS03";
                public const string Description = "Create MSE Customer";
            }

            public struct UpdateMSE
            {
                public const string Code = "CUS04";
                public const string Description = "Update MSE Customer";
            }

            public struct GetById
            {
                public const string Code = "CUS05";
                public const string Description = "Get Customer By Id";
            }

            public struct IdentifySSE
            {
                public const string Code = "CUS06";
                public const string Description = "Identify SSE Customer";
            }

            public struct SignInSSE
            {
                public const string Code = "CUS07";
                public const string Description = "Sign In SSE Customer";
            }

            public struct CheckTwoFACode
            {
                public const string Code = "CUS08";
                public const string Description = "Check 2FA Code Customer";
            }
        }
    }
}
