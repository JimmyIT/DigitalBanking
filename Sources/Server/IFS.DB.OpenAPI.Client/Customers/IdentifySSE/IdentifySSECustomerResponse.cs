using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Customers.IdentifySSE
{
    public class IdentifySSECustomerResponse
    {
        public string InternalId { get; set; }
        public int PasswordLength { get; set; }
    }
}
