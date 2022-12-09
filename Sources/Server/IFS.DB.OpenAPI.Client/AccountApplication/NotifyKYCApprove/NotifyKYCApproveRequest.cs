using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.AccountApplication.NotifyKYCApprove
{
    public class NotifyKYCApproveRequest
    {
        public int LinkId { get; set; }
        public int RequestId { get; set; }
        public Guid AMLRefId { get; set; }
        public string Reference { get; set; }
    }
}
