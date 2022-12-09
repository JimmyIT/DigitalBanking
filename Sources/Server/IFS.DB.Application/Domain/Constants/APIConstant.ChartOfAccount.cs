namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct ChartOfAccount
            {
                public const string GetOnlineAvailableByEntityType = "online-available/entity-type/{entityTypeId}";
                public const string GetOnlineCOAByEntityTypeIdForNewApp = "online-available/new-application/entity-type/{entityTypeId}";
                public const string GetCurrenciesByOnlineCOA = "online-available/{chartOfAccountId}/currencies";
            }
        }

        public partial struct Response
        {
            public struct ChartOfAccount
            {
                public const string OnlineAvailableRead = "Online Available Chart Of Account Read";
                public const string OnlineAvailableError = "Online Available Chart Of Account Error";

                public const string CurrenciesOnlineAvailableRead = "Currencies Online Available By Chart Of Account Read";
                public const string CurrenciesOnlineAvailableError = "Currencies Online Available By Chart Of Account Error";
            }
        }
    }
}
