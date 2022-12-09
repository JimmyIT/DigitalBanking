namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIMessageActionInfo
    {
        public struct Account
        {
            public struct CreateBWOnBoarding
            {
                public const string Code = "ACC01";
                public const string Description = "Create Bankware OnBoarding Account";
            }

            public struct Create
            {
                public const string Code = "ACC02";
                public const string Description = "Create Account";
            }

            public struct UpdateBWInternetFlag
            {
                public const string Code = "ACC03";
                public const string Description = "Update Bankware Account Internet Flag";
            }

            public struct DeleteByAccountNumber
            {
                public const string Code = "ACC04";
                public const string Description = "Delete Account By Account Number";
            }
        }
    }
}
