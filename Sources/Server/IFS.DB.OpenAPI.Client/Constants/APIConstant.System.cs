namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
        {
            public struct System
            {
                public const string AllowLogon = "allow-logon";
            }
        }

        public partial struct EndPoint
        {
            public struct System
            {
                private const string This = DefaultRoute + "/" + Route.Controller.System + "/";
                public const string AllowLogon = This + Route.System.AllowLogon;
            }
        }
    }
}
