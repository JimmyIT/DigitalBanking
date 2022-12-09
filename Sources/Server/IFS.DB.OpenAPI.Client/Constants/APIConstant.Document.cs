namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
        {
            public struct Document
            {
                public const string GetAMLRulesByEntityType = "aml/entity-type/{entityTypeId}";
                public const string UploadAML = "aml/upload";
                public const string GetShuftiProVerificationURL = "shufti-pro/verification-url";
                public const string GetShuftiProVerificationStatus = "shufti-pro/verification-status";
            }
        }

        public partial struct EndPoint
        {
            public struct Document
            {
                private const string This = DefaultRoute + "/" + Route.Controller.Document + "/";
                public const string GetAMLRulesByEntityType = This + Route.Document.GetAMLRulesByEntityType;
                public const string UploadAML = This + Route.Document.UploadAML;
                public const string GetShuftiProVerificationURL = This + Route.Document.GetShuftiProVerificationURL;
                public const string GetShuftiProVerificationStatus = This + Route.Document.GetShuftiProVerificationStatus;
            }
        }
    }
}
