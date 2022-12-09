using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Bankware.Accounts.Create
{
    public class CreateAccountRequest
    {
        public string ChartOfAccount { get; set; }
        public string ClientNumber { get; set; }
        public string Currency { get; set; }
        public string TemplateCustomerNumber { get; set; }
    }
}
