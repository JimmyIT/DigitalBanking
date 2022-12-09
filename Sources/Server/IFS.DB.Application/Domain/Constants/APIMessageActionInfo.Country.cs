namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIMessageActionInfo
    {
        public struct Country
        {
            public struct GetAll
            {
                public const string Code = "CTRY01";
                public const string Description = "Get All Countries";
            }

            public struct GetAML
            {
                public const string Code = "CTRY02";
                public const string Description = "Get All AML Countries";
            }
        }
    }
}
