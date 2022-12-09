using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Accounts.Create
{
    public class CreateAccountRequest
    {
        public string AccountNumber { get; set; }
        public string ClientNumber { get; set; }
    }
}
