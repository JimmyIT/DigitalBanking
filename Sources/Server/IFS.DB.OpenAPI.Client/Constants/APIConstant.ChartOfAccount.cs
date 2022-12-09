namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
        {
            public struct ChartOfAccount
            {
                public const string GetOnlineAvailableByEntityType = "online-available/entity-type/{entityTypeId}";
                public const string GetOnlineCOAByEntityTypeIdForNewApp = "online-available/new-application/entity-type/{entityTypeId}";
                public const string GetCurrenciesByOnlineCOA = "online-available/{chartOfAccountId}/currencies";
            }
        }

        public partial struct EndPoint
        {
            public struct ChartOfAccount
            {
                private const string This = DefaultRoute + "/" + Route.Controller.ChartOfAccount + "/";
                public const string GetByEntityTypeId = This + Route.ChartOfAccount.GetOnlineAvailableByEntityType;
                public const string GetOnlineCOAByEntityTypeIdForNewApp = This + Route.ChartOfAccount.GetOnlineCOAByEntityTypeIdForNewApp;
                public const string GetCurrenciesByOnlineCOA = This + Route.ChartOfAccount.GetCurrenciesByOnlineCOA;
            }
        }
    }
}
