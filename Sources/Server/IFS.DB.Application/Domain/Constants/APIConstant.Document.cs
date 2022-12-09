namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct Document
            {
                public const string GetAMLRulesByEntityType = "aml/entity-type/{entityTypeId}";
                public const string UploadAML = "aml/upload";
                public const string GetShuftiProVerificationURL = "shufti-pro/verification-url";
                public const string GetShuftiProVerificationStatus = "shufti-pro/verification-status";
            }
        }

        public partial struct Response
        {
            public struct Document
            {
                public const string ReadAML = "AML Document Rules Read";
                public const string UploadAML = "AML Document Uploaded";
                public const string ErrorAML = "AML Document Rules Error";

                public const string ReadShuftiPro = "Shufti Pro Document Read";
                public const string ErrorShuftiPro = "Shufti Pro Document Error";
            }
        }
    }
}
