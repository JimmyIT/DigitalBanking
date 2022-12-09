using IFS.DB.OpenAPI.Client.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Client.Clients.CreateAML
{
    public class CreateAMLClientResponse
    {
        public string EmailAddress { get; set; }
        public string DataItemID { get; set; }
        public string AMLtracRefId { get; set; }
        public AMLCustomerStatusEnum Status { get; set; }
    }
}
