using IFS.DB.Application.Domain.Enums;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.UpdateStatus
{
    public class UpdateAccountApplicationStatusRequest
    {
        public Guid ApplicationId { get; set; }
        public AccountApplicationStatusEnum Status { get; set; }
        public string ClientNumber { get; set; }
        public string AccountNumber { get; set; }
        public string AMLtracRefId { get; set; }
        public string ErrorDescription { get; set; }
    }
}
