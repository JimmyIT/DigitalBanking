namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct Account
            {
                public const string Create = "";
                public const string CreateBWOnBoarding = "bankware-onboarding";
                public const string UpdateBWInternetFlag = "bankware/internet-flag";
                public const string DeleteByAccountNumber = "{accountNumber}";
            }
        }

        public partial struct Response
        {
            public struct Account
            {
                public const string Create = "Account Created";
                public const string Delete = "Account Deleted";
                public const string Error = "Account Error";

                public const string CreateBWOnBoarding = "Bankware OnBoarding Account Created";
                public const string ErrorBWOnBoarding = "Bankware OnBoarding Account Error";

                public const string UpdateBW = "Bankware Account Updated";
                public const string ErrorBW = "Bankware Account Error";
            }
        }
    }
}
