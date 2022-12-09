namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
        {
            public struct Country
            {
                public const string GetAll = "";
                public const string GetAMLCountries = "aml";
            }
        }

        public partial struct EndPoint
        {
            public struct Country
            {
                private const string This = DefaultRoute + "/" + Route.Controller.Country + "/";
                public const string GetAll = This + Route.Country.GetAll;
                public const string GetAMLCountries = This + Route.Country.GetAMLCountries;
            }
        }
    }
}
