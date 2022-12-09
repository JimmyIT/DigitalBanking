using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Customers.IdentifySSE
{
    public class IdentifySSECustomerResponse
    {
        public string InternalId { get; set; }
        public int PasswordLength { get; set; }
    }
}
