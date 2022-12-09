namespace IFS.DB.Application.Domain.Constants
{
    public partial struct APIConstant
    {
        public partial struct Route
        {
            public struct Customer
            {
                public const string CreateSSE = "sse";
                public const string UpdateSSE = "sse";
                public const string CreateMSE = "mse";
                public const string UpdateMSE = "mse";
                public const string GetById = "{id}";
                public const string IdentifySSE = "sse/identify";
                public const string SignInSSE = "sse/sign-in";
                public const string CheckTwoFACode = "check-two-fa-code";
            }
        }

        public partial struct Response
        {
            public struct Customer
            {
                public const string Read = "Customer Read";
                public const string Create = "Customer Created";
                public const string Update = "Customer Updated";
                public const string Error = "Customer Error";
            }
        }
    }
}
