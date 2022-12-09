using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Customers.CheckTwoFACode
{
    public class CheckTwoFACodeCustomerRequest
    {
        public string InternalId { get; set; }
        public string FACode { get; set; }
    }
}
