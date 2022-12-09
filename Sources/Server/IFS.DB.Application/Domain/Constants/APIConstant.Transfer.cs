namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct Transfer
            {
                public const string Create = "";
            }
        }

        public partial struct Response
        {
            public struct Transfer
            {
                public const string Create = "Transfer Created";
                public const string Error = "Transfer Error";
                public const string Read = "Transfer Read";
            }
        }
    }
}
