using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.AMLtrac.Customers.Import
{
    public class ImportCustomerResponse
    {
        public string EmailAddress { get; set; }
        public string DataItemID { get; set; }
        public string AMLtracRefId { get; set; }
    }
}
