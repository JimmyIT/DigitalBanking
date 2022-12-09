namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
        {
            public struct Parameter
            {
                public const string GetByKey = "{paramKey}";
            }
        }

        public partial struct EndPoint
        {
            public struct Parameter
            {
                private const string This = DefaultRoute + "/" + Route.Controller.Parameter + "/";
                public const string GetByKey = This + Route.Parameter.GetByKey;
            }
        }
    }
}
