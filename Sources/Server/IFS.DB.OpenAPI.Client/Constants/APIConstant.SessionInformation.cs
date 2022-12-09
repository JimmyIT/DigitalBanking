namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
        {
            public struct SessionInformation
            {
                public const string GetById = "{id}";
                public const string Create = "";
                public const string Update = "{id}";
                public const string Reset = "{id}/reset";
                public const string Delete = "{id}";
            }
        }

        public partial struct EndPoint
        {
            public struct SessionInformation
            {
                private const string This = DefaultRoute + "/" + Route.Controller.SessionInformation + "/";
                public const string GetById = This + Route.SessionInformation.GetById;
                public const string Create = This + Route.SessionInformation.Create;
                public const string Update = This + Route.SessionInformation.Update;
                public const string Reset = This + Route.SessionInformation.Reset;
                public const string Delete = This + Route.SessionInformation.Delete;
            }
        }
    }
}
