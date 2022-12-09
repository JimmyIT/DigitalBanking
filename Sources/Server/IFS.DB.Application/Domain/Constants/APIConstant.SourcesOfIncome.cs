namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct SourcesOfIncome
            {
                public const string GetAMLJobTypes = "aml/job-types";
                public const string GetAMLOccupationTypes = "aml/occupation-types";
                public const string GetAMLEmployerBusinessTypes = "aml/employer-business-types";
            }
        }

        public partial struct Response
        {
            public struct SourcesOfIncome
            {
                public const string ErrorAMLJobTypes = "AML JobTypes Error";
                public const string ReadAMLJobTypes = "AML JobTypes Read";

                public const string ErrorAMLOccupations = "AML Occupations Error";
                public const string ReadAMLOccupations = "AML Occupations Read";

                public const string ErrorAMLBusinessTypes = "AML Businesses Error";
                public const string ReadAMLBusinessTypes = "AML Businesses Read";
            }
        }
    }
}
