using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Constants
{
    public struct BankwareAPIURLConst
    {
        public const string DefaultQuery = "?op=";
        public const string DefaultRouteV2 = "/api/v2";

        public struct Route
        {
            public struct Controler
            {
                public const string Account = "accounts";
                public const string Customer = "customers";
                public const string OnlineCOA = "chart-of-account/online-available";
            }

            public struct Account
            {
                public const string GetByAccountNumber = "{accountNumber}";
                public const string Create = "open-account";
                public const string UpdateInternetFlag = "{accountNumber}/update-internet-flag";
            }

            public struct Customer
            {
                public const string CheckEmailExist = "email/checkExist/{email}";
            }

            public struct OnlineCOA
            {
                public const string GetCurrenciesByOnlineCOA = "{chartOfAccountId}/currencies";
                public const string GetOnlineCOAByEntityTypeIdForNewApp = "new-application/entity-type-id/{entityTypeId}";
                public const string GetOnlineCOAsByEntityTypeId = "entity-type-id/{entityTypeId}";
            }
        }

        public struct EndPoint
        {
            public struct Account
            {
                public const string GetByAccountNumber = $"{DefaultRouteV2}/{Route.Controler.Account}/{Route.Account.GetByAccountNumber}";
                public const string Create = $"{DefaultRouteV2}/{Route.Controler.Account}/{Route.Account.Create}";
                public const string UpdateInternetFlag = $"{DefaultRouteV2}/{Route.Controler.Account}/{Route.Account.UpdateInternetFlag}";
            }

            public struct Customer
            {
                public const string CheckEmailExist = $"{DefaultRouteV2}/{Route.Controler.Customer}/{Route.Customer.CheckEmailExist}";
            }

            public struct OnlineCOA
            {
                public const string GetCurrenciesByOnlineCOA = $"{DefaultRouteV2}/{Route.Controler.OnlineCOA}/{Route.OnlineCOA.GetCurrenciesByOnlineCOA}";
                public const string GetOnlineCOAByEntityTypeIdForNewApp = $"{DefaultRouteV2}/{Route.Controler.OnlineCOA}/{Route.OnlineCOA.GetOnlineCOAByEntityTypeIdForNewApp}";
                public const string GetOnlineCOAsByEntityTypeId = $"{DefaultRouteV2}/{Route.Controler.OnlineCOA}/{Route.OnlineCOA.GetOnlineCOAsByEntityTypeId}";
            }
        }
    }
}
