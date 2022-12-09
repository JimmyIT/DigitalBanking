namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIMessageActionInfo
    {
        public struct AccountApplication
        {
            public struct GetByEmail
            {
                public const string Code = "ACCAPP01";
                public const string Description = "Get Account Application By Email";
            }

            public struct GetById
            {
                public const string Code = "ACCAPP02";
                public const string Description = "Get Account Application By Id";
            }

            public struct RegisterOnboarding
            {
                public const string Code = "ACCAPP03";
                public const string Description = "Register Onboarding Account Application";
            }

            public struct Update
            {
                public const string Code = "ACCAPP04";
                public const string Description = "Update Account Application";
            }

            public struct UpdateStatus
            {
                public const string Code = "ACCAPP05";
                public const string Description = "Update Account Application Status";
            }

            public struct UpdateKYCStatus
            {
                public const string Code = "ACCAPP06";
                public const string Description = "Update Account Application KYC Status";
            }

            public struct Create
            {
                public const string Code = "ACCAPP07";
                public const string Description = "Create Account Application";
            }

            public struct UpdateOnboarding
            {
                public const string Code = "ACCAPP08";
                public const string Description = "Update Onboarding Account Application";
            }

            public struct GetBySessionId
            {
                public const string Code = "ACCAPP09";
                public const string Description = "Get Account Application By Session Id";
            }

            public struct UpdateRegisterOnboarding
            {
                public const string Code = "ACCAPP10";
                public const string Description = "Update Register Onboarding Account Application";
            }

            public struct GetClearDown
            {
                public const string Code = "ACCAPP11";
                public const string Description = "Get Account Application Clear Down List";
            }

            public struct DeleteById
            {
                public const string Code = "ACCAPP12";
                public const string Description = "Delete Account Application By Id";
            }

            public struct RegisterKYCOnboarding
            {
                public const string Code = "ACCAPP13";
                public const string Description = "Register KYC Onboarding Account Application";
            }

            public struct RegisterEmailOnboarding
            {
                public const string Code = "ACCAPP14";
                public const string Description = "Register Email Onboarding Account Application";
            }

            public struct CreateApplicationAcceptedNotification
            {
                public const string Code = "ACCAPP15";
                public const string Description = "Create Application Accepted Notification";
            }

            public struct NotifyKYCApprove
            {
                public const string Code = "ACCAPP16";
                public const string Description = "Notify Application KYC Approve";
            }

            public struct ConfirmOnboarding
            {
                public const string Code = "ACCAPP17";
                public const string Description = "Confirm Onboarding Account Application";
            }
        }
    }
}
