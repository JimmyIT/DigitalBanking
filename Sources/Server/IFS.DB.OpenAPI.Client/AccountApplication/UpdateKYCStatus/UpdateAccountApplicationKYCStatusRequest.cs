using IFS.DB.OpenAPI.Client.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.AccountApplication.UpdateKYCStatus
{
    public class UpdateAccountApplicationKYCStatusRequest
    {
        public Guid ApplicationId { get; set; }
        public AccountApplicationStatusEnum Status { get; set; }
    }
}
