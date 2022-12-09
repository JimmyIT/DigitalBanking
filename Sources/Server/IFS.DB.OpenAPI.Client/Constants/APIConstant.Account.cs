namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
        {
            public struct Account
            {
                public const string Create = "";
                public const string CreateBWOnBoarding = "bankware-onboarding";
                public const string UpdateBWInternetFlag = "bankware/internet-flag";
                public const string DeleteByAccountNumber = "{accountNumber}";
            }
        }

        public partial struct EndPoint
        {
            public struct Account
            {
                private const string This = DefaultRoute + "/" + Route.Controller.Account + "/";
                public const string Create = This + Route.Account.Create;
                public const string CreateBWOnBoarding = This + Route.Account.CreateBWOnBoarding;
                public const string UpdateBWInternetFlag = This + Route.Account.UpdateBWInternetFlag;
                public const string DeleteByAccountNumber = This + Route.Account.DeleteByAccountNumber;
            }
        }
    }
}
