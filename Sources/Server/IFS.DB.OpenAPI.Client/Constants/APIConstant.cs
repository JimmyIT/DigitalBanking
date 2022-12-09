namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private const string DefaultRoute = "api";

        private partial struct Route
        {
            public struct Controller
            {
                public const string Account = "accounts";
                public const string AccountApplication = "account-applications";
                public const string ChartOfAccount = "chart-of-accounts";
                public const string Client = "clients";
                public const string Country = "countries";
                public const string Currency = "currencies";
                public const string Customer = "customers";
                public const string Document = "documents";
                public const string Message = "messages";
                public const string Notification = "notifications";
                public const string Parameter = "parameters";
                public const string SessionInformation = "session-informations";
                public const string SourcesOfIncome = "sources-of-incomes";
                public const string System = "systems";
                public const string Title = "titles";
                public const string Token = "token";
                public const string Transfer = "transfers";
            }
        }

        public partial struct EndPoint
        {
            public const string Token = Route.Controller.Token;
        }
    }
}
