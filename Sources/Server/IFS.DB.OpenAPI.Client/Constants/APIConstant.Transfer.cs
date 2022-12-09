namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
        {
            public struct Transfer
            {
                public const string Create = "";
            }
        }

        public partial struct EndPoint
        {
            public struct Transfer
            {
                private const string This = DefaultRoute + "/" + Route.Controller.Transfer + "/";
                public const string Create = This + Route.Transfer.Create;
            }
        }
    }
}
