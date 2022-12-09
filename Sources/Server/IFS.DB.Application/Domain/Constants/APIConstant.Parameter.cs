namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct Parameter
            {
                public const string GetByKey = "{paramKey}";
            }
        }

        public partial struct Response
        {
            public struct Parameter
            {
                public const string Error = "Parameter Error";
                public const string Read = "Parameter Read";
            }
        }
    }
}
