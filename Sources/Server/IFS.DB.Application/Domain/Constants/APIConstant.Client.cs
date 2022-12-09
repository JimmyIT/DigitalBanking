namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct Client
            {
                public const string CreateAML = "aml";
                public const string CreateOnBoarding = "onboarding";
                public const string GetAMLById = "aml/{id}";
                public const string DeleteByClientNumber = "{clientNumber}";
                public const string ApproveAML = "aml/approve";
                public const string CheckMissingDocument = "aml/check-document";
                public const string MoveAMLToDataCapture = "aml/move-to-data-capture";
                public const string MoveAMLToRiskReview = "aml/move-to-risk-review";
            }
        }

        public partial struct Response
        {
            public struct Client
            {
                public const string Delete = "Client Deleted";
                public const string Error = "Client Error";

                public const string CreateAML = "AML Client Created";
                public const string UpdateAML = "AML Client Updated";
                public const string ReadAML = "AML Client Read";
                public const string ErrorAML = "AML Client Error";

                public const string CreateOnBoarding = "OnBoarding Client Created";
                public const string ErrorOnBoarding = "OnBoarding Client Error";
            }
        }
    }
}
