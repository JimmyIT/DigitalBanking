namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct AccountApplication
            {
                public const string GetByEmail = "email/{email}";
                public const string GetById = "{id}";
                public const string RegisterOnboarding = "onboarding/register";
                public const string Update = "";
                public const string UpdateStatus = "status";
                public const string UpdateKYCStatus = "kyc-status";
                public const string Create = "";
                public const string UpdateOnboarding = "onboarding";
                public const string GetBySessionId = "session-id/{sessionId}";
                public const string UpdateRegisterOnboarding = "onboarding/register";
                public const string GetClearDown = "clear-down";
                public const string DeleteById = "{id}";
                public const string RegisterKYCOnboarding = "onboarding/register/kyc";
                public const string RegisterEmailOnboarding = "onboarding/register/email";
                public const string CreateApplicationAcceptedNotification = "create-application-accepted-notification";
                public const string NotifyKYCApprove = "notify-kyc-approve";
                public const string ConfirmOnboarding = "onboarding/confirm";
            }
        }

        public partial struct Response
        {
            public struct AccountApplication
            {
                public const string Read = "Account Application Read";
                public const string Create = "Account Application Created";
                public const string Update = "Account Application Updated";
                public const string Delete = "Account Application Deleted";
                public const string Error = "Account Application Error";

                public const string CreateOnboarding = "Onboarding Account Application Created";
                public const string UpdateOnboarding = "Onboarding Account Application Updated";
                public const string ErrorOnboarding = "Onboarding Account Application Error";
            }
        }
    }
}
