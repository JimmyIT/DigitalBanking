namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct System
            {
                public const string AllowLogon = "allow-logon";
            }
        }

        public partial struct Response
        {
            public struct System
            {
                public const string Read = "System Read";
                public const string Error = "System Error";
            }
        }
    }
}
