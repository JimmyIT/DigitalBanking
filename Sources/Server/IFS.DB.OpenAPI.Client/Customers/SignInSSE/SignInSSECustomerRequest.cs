using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Customers.SignInSSE
{
    public class SignInSSECustomerRequest
    {
        public string InternalId { get; set; }
        public IList<PasswordCharacter> PasswordCharacters { get; set; }
        public string SecurityCode { get; set; }
    }

    public class PasswordCharacter
    {
        public int Position { get; set; }
        public string Keyword { get; set; }
    }
}
