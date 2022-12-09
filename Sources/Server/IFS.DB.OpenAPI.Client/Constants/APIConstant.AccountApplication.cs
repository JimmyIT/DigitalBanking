namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
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

        public partial struct EndPoint
        {
            public struct AccountApplication
            {
                private const string This = DefaultRoute + "/" + Route.Controller.AccountApplication + "/";
                public const string GetByEmail = This + Route.AccountApplication.GetByEmail;
                public const string GetById = This + Route.AccountApplication.GetById;
                public const string RegisterOnboarding = This + Route.AccountApplication.RegisterOnboarding;
                public const string Update = This + Route.AccountApplication.Update;
                public const string UpdateStatus = This + Route.AccountApplication.UpdateStatus;
                public const string UpdateKYCStatus = This + Route.AccountApplication.UpdateKYCStatus;
                public const string Create = This + Route.AccountApplication.Create;
                public const string UpdateOnboarding = This + Route.AccountApplication.UpdateOnboarding;
                public const string GetBySessionId = This + Route.AccountApplication.GetBySessionId;
                public const string UpdateRegisterOnboarding = This + Route.AccountApplication.UpdateRegisterOnboarding;
                public const string GetClearDown = This + Route.AccountApplication.GetClearDown;
                public const string DeleteById = This + Route.AccountApplication.DeleteById;
                public const string RegisterKYCOnboarding = This + Route.AccountApplication.RegisterKYCOnboarding;
                public const string RegisterEmailOnboarding = This + Route.AccountApplication.RegisterEmailOnboarding;
                public const string CreateApplicationAcceptedNotification = This + Route.AccountApplication.CreateApplicationAcceptedNotification;
                public const string NotifyKYCApprove = This + Route.AccountApplication.NotifyKYCApprove;
                public const string ConfirmOnboarding = This + Route.AccountApplication.ConfirmOnboarding;
            }
        }
    }
}
