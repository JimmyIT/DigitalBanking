using IFS.DB.Application.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.UpdateKYCStatus
{
    public class UpdateAccountApplicationKYCStatusRequest
    {
        public Guid ApplicationId { get; set; }
        public AccountApplicationStatusEnum Status { get; set; }
    }
}
