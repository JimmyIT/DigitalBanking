using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.AMLtrac.Customers.CheckMissingDocument
{
    public class CheckCustomerMissingDocumentResponse
    {
        public Guid AMLtracRefId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
