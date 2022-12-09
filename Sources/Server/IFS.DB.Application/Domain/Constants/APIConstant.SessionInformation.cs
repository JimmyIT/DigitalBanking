namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
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

        public partial struct Response
        {
            public struct SessionInformation
            {
                public const string Create = "Session Information Created";
                public const string Delete = "Delete Information Deleted";
                public const string Read = "Session Information Read";
                public const string Update = "Session Information Updated";
                public const string Error = "Session Information Error";
            }
        }
    }
}
