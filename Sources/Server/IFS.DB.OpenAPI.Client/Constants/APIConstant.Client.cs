namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
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

        public partial struct EndPoint
        {
            public struct Client
            {
                private const string This = DefaultRoute + "/" + Route.Controller.Client + "/";
                public const string CreateAML = This + Route.Client.CreateAML;
                public const string CreateOnBoarding = This + Route.Client.CreateOnBoarding;
                public const string GetAMLById = This + Route.Client.GetAMLById;
                public const string DeleteByClientNumber = This + Route.Client.DeleteByClientNumber;
                public const string ApproveAML = This + Route.Client.ApproveAML;
                public const string CheckMissingDocument = This + Route.Client.CheckMissingDocument;
                public const string MoveAMLToDataCapture = This + Route.Client.MoveAMLToDataCapture;
                public const string MoveAMLToRiskReview = This + Route.Client.MoveAMLToRiskReview;
            }
        }
    }
}
