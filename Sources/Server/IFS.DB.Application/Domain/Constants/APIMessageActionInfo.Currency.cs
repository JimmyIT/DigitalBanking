namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIMessageActionInfo
    {
        public struct Currency
        {
            public struct GetAll
            {
                public const string Code = "CCY01";
                public const string Description = "Get All Currencies";
            }

            public struct GetAML
            {
                public const string Code = "CCY02";
                public const string Description = "Get All AML Currencies";
            }
        }
    }
}
