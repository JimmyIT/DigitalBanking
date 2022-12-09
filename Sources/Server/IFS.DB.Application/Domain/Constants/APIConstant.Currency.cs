namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct Currency
            {
                public const string GetAll = "";
                public const string GetAML = "aml";
            }
        }

        public partial struct Response
        {
            public struct Currency
            {
                public const string Read = "Currency Read";
                public const string Error = "Currency Error";

                public const string ReadAML = "AML Currency Read";
                public const string ErrorAML = "AML Currency Error";
            }
        }
    }
}
