namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIMessageActionInfo
    {
        public struct SessionInformation
        {
            public struct GetById
            {
                public const string Code = "SESINFO01";
                public const string Description = "Get Session Information By Id";
            }

            public struct Create
            {
                public const string Code = "SESINFO02";
                public const string Description = "Create Session Information";
            }

            public struct Update
            {
                public const string Code = "SESINFO03";
                public const string Description = "Update Session Information";
            }

            public struct Reset
            {
                public const string Code = "SESINFO04";
                public const string Description = "Reset Session Information";
            }

            public struct Delete
            {
                public const string Code = "SESINFO05";
                public const string Description = "Delete Session Information";
            }
        }
    }
}
