namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
        {
            public struct SourcesOfIncome
            {
                public const string GetAMLJobTypes = "aml/job-types";
                public const string GetAMLOccupationTypes = "aml/occupation-types";
                public const string GetAMLEmployerBusinessTypes = "aml/employer-business-types";
            }
        }

        public partial struct EndPoint
        {
            public struct SourcesOfIncome
            {
                private const string This = DefaultRoute + "/" + Route.Controller.SourcesOfIncome + "/";
                public const string GetAMLJobTypes = This + Route.SourcesOfIncome.GetAMLJobTypes;
                public const string GetAMLOccupationTypes = This + Route.SourcesOfIncome.GetAMLOccupationTypes;
                public const string GetAMLEmployerBusinessTypes = This + Route.SourcesOfIncome.GetAMLEmployerBusinessTypes;
            }
        }
    }
}
