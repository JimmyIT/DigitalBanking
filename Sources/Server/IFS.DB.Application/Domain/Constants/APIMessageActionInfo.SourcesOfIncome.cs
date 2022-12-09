namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIMessageActionInfo
    {
        public struct SourcesOfIncome
        {
            public struct GetAMLJobTypes
            {
                public const string Code = "INC01";
                public const string Description = "Get All AML JobTypes";
            }

            public struct GetAMLOccupationTypes
            {
                public const string Code = "INC02";
                public const string Description = "Get All AML Occupation Types";
            }

            public struct GetAMLEmployerBusinessTypes
            {
                public const string Code = "INC03";
                public const string Description = "Get AML Employer BusinessTypes";
            }
        }
    }
}
