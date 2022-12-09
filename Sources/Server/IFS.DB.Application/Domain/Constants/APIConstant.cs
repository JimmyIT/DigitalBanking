namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public const string DefaultRoute = "api";

        public struct Header
        {
            public const string x_idempotency_key = "x-idempotency-key";
        }

        public partial struct Route
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

        public partial struct Response
        {
            public struct Token
            {
                public const string Create = "Token Created";
                public const string Error = "Token Error";
            }
        }

        public struct Tag
        {
            public const string Account = "Accounts";
            public const string AccountApplication = "Account Applications";
            public const string ChartOfAccounts = "Chart Of Accounts";
            public const string Client = "Clients";
            public const string Country = "Countries";
            public const string Currency = "Currencies";
            public const string Customer = "Customers";
            public const string Document = "Documents";
            public const string Message = "Messages";
            public const string Notification = "Notifications";
            public const string Parameter = "Parameters";
            public const string SessionInformation = "Session Informations";
            public const string SourcesOfIncome = "Sources Of Incomes";
            public const string System = "Systems";
            public const string Title = "Titles";
            public const string Token = "_Token";
            public const string Transfer = "Transfers";
        }
    }
}
