namespace IFS.DB.OpenAPI.Client.Constants
{
    public partial struct APIConstant
    {
        private partial struct Route
        {
            public struct Customer
            {
                public const string CreateSSE = "sse";
                public const string UpdateSSE = "sse";
                public const string GetById = "{id}";
                public const string IdentifySSE = "sse/identify";
                public const string SignInSSE = "sse/sign-in";
                public const string CheckTwoFACode = "check-two-fa-code";
            }
        }

        public partial struct EndPoint
        {
            public struct Customer
            {
                private const string This = DefaultRoute + "/" + Route.Controller.Customer + "/";
                public const string CreateSSE = This + Route.Customer.CreateSSE;
                public const string UpdateSSE = This + Route.Customer.UpdateSSE;
                public const string GetById = This + Route.Customer.GetById;
                public const string IdentifySSE = This + Route.Customer.IdentifySSE;
                public const string SignInSSE = This + Route.Customer.SignInSSE;
                public const string CheckTwoFACode = This + Route.Customer.CheckTwoFACode;
            }
        }
    }
}
