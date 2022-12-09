namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
        {
            public struct Currency
            {
                public const string GetAll = "";
                public const string GetAML = "aml";
            }
        }

        public partial struct EndPoint
        {
            public struct Currency
            {
                private const string This = DefaultRoute + "/" + Route.Controller.Currency + "/";
                public const string GetAll = This + Route.Currency.GetAll;
                public const string GetAML = This + Route.Currency.GetAML;
            }
        }
    }
}
