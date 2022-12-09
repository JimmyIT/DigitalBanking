namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIMessageActionInfo
    {
        public struct Message
        {
            public struct GetByStatusAndDirection
            {
                public const string Code = "MSG01";
                public const string Description = "Get MqMessage By Status And Direction";
            }

            public struct UpdateStatus
            {
                public const string Code = "MSG02";
                public const string Description = "Update MqMessage Status";
            }

            public struct Create
            {
                public const string Code = "MSG03";
                public const string Description = "Create Message";
            }
        }
    }
}
