namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
        {
            public struct Messaage
            {
                public const string GetByStatusAndDirection = "status/{status}/direction/{direction}";
                public const string UpdateStatus = "status";
                public const string Create = "";
            }
        }

        public partial struct EndPoint
        {
            public struct Message
            {
                private const string This = DefaultRoute + "/" + Route.Controller.Message + "/";
                public const string GetByStatusAndDirection = This + Route.Messaage.GetByStatusAndDirection;
                public const string UpdateStatus = This + Route.Messaage.UpdateStatus;
                public const string Create = This + Route.Messaage.Create;
            }
        }
    }
}
