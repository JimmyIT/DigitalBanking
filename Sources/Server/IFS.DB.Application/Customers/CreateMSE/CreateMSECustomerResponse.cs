using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Customers.CreateMSE
{
    public class CreateMSECustomerResponse
    {
        public string LogonID { get; set; }
        public string MSEAuthorityCode { get; set; }
        public List<MSEUser> Users { get; set; }
    }
}
