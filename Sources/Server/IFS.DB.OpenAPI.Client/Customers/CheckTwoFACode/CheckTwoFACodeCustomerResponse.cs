using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Customers.CheckTwoFACode
{
    public class CheckTwoFACodeCustomerResponse
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpriesIn { get; set; }
    }
}
