using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Customers.CheckTwoFACode
{
    public class CheckTwoFACodeCustomerRequest
    {
        public string InternalId { get; set; }
        public string FACode { get; set; }
    }
}
