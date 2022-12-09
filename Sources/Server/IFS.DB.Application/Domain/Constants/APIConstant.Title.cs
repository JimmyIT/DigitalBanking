namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct Title
            {
                public const string GetAML = "aml";
            }
        }

        public partial struct Response
        {
            public struct Title
            {
                public const string ErrorAML = "AML Title Error";
                public const string ReadAML = "AML Title Read";
            }
        }
    }
}
