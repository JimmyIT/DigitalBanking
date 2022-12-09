namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct Message
            {
                public const string GetByStatusAndDirection = "status/{status}/direction/{direction}";
                public const string UpdateStatus = "status";
                public const string Create = "";
            }
        }

        public partial struct Response
        {
            public struct Message
            {
                public const string Create = "Message Created";
                public const string Read = "Message Read";
                public const string Update = "Message Updated";
                public const string Error = "Message Error";
            }
        }
    }
}
