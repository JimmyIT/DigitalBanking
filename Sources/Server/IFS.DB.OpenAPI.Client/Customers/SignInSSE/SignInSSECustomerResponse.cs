using IFS.DB.OpenAPI.Client.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Customers.SignInSSE
{
    public class SignInSSECustomerResponse
    {
        public TwoFactorAuthTypeEnum AuthType { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpriesIn { get; set; }
    }
}
