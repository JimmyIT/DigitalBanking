namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIMessageActionInfo
    {
        public struct ChartOfAccount
        {
            public struct GetOnlineAvailableByEntityType
            {
                public const string Code = "COA01";
                public const string Description = "Get Online Available Chart Of Account By Entity Type";
            }

            public struct GetOnlineCOAByEntityTypeIdForNewApp
            {
                public const string Code = "COA02";
                public const string Description = "Get Online Available Chart Of Account By Entity Type and Available New Applications";
            }

            public struct GetCurrenciesByOnlineCOA
            {
                public const string Code = "COA03";
                public const string Description = "Get Currencies Online Available By Chart Of Account ID";
            }
        }
    }
}
