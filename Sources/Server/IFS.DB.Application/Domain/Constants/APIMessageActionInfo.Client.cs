namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIMessageActionInfo
    {
        public struct Client
        {
            public struct CreateAML
            {
                public const string Code = "CLI01";
                public const string Description = "Create AML Client";
            }

            public struct CreateOnBoarding
            {
                public const string Code = "CLI02";
                public const string Description = "Create OnBoarding Client";
            }

            public struct GetAMLById
            {
                public const string Code = "CLI03";
                public const string Description = "Get AML Client By Id";
            }

            public struct DeleteByClientNumber
            {
                public const string Code = "CLI04";
                public const string Description = "Delete Client By Client Number";
            }

            public struct ApproveAML
            {
                public const string Code = "CLI05";
                public const string Description = "Approve AML Client";
            }

            public struct CheckMissingDocument
            {
                public const string Code = "CLI06";
                public const string Description = "Check AML Client Missing Document";
            }

            public struct MoveAMLToDataCapture
            {
                public const string Code = "CLI07";
                public const string Description = "Move AML Client To Data Capture";
            }

            public struct MoveAMLToRiskReview
            {
                public const string Code = "CLI08";
                public const string Description = "Move AML Client To Risk Review";
            }
        }
    }
}
