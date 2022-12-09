namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
        {
            public struct Title
            {
                public const string GetAML = "aml";
            }
        }

        public partial struct EndPoint
        {
            public struct Title
            {
                private const string This = DefaultRoute + "/" + Route.Controller.Title + "/";
                public const string GetAML = This + Route.Title.GetAML;
            }
        }
    }
}
