namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct Country
            {
                public const string GetAll = "";
                public const string GetAML = "aml";
            }
        }

        public partial struct Response
        {
            public struct Country
            {
                public const string Read = "Country Read";
                public const string Error = "Country Error";
            }
        }
    }
}
