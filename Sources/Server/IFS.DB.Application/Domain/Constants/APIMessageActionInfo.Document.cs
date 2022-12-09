namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIMessageActionInfo
    {
        public struct Document
        {
            public struct GetAMLRulesByEntityType
            {
                public const string Code = "DOC01";
                public const string Description = "Get AML Document Rules By Entity Type";
            }

            public struct UploadAML
            {
                public const string Code = "DOC02";
                public const string Description = "Upload AML Document";
            }

            public struct GetShuftiProVerificationURL
            {
                public const string Code = "DOC03";
                public const string Description = "Get Shufti Pro Verification URL";
            }

            public struct GetShuftiProVerificationStatus
            {
                public const string Code = "DOC04";
                public const string Description = "Get Shufti Pro Verification Status";
            }
        }
    }
}
