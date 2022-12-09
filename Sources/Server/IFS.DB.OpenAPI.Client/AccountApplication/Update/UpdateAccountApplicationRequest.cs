using IFS.DB.OpenAPI.Client.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.AccountApplication.Update
{
    public class UpdateAccountApplicationRequest
    {
        public Guid ApplicationId { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public AccountApplicationStatusEnum Status { get; set; }
        public string ClientNumber { get; set; }
        public string AccountNumber { get; set; }
        public string AMLtracRefId { get; set; }
        public Guid SessionId { get; set; }
        public string LogonId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string MessageContent { get; set; }
        public string ErrorDescription { get; set; }
        public bool CanReSubmit { get; set; }
    }
}
