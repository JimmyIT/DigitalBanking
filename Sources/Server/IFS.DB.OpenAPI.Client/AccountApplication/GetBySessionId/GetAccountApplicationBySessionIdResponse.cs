using IFS.DB.OpenAPI.Client.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.AccountApplication.GetBySessionId
{
    public class GetAccountApplicationBySessionIdResponse
    {
        public Guid ApplicationId { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public AccountApplicationStatusEnum Status { get; set; }
        public string ClientNumber { get; set; }
        public string AccountNumber { get; set; }
        public string AMLtracRefId { get; set; }
        public string ShuftiProRefId { get; set; }
        public string ShuftiProVerificationURL { get; set; }
        public DateTime? ShuftiProURLExpiryDate { get; set; }
        public string KYCRefId { get; set; }
        public string BackCallBackURL { get; set; }
        public string SubmitCallBackURL { get; set; }
        public string AdditionalDocumentRequirement { get; set; }
        public int LatestStep { get; set; }
        public Guid SessionId { get; set; }
        public string LogonId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string MessageContent { get; set; }
        public string ErrorDescription { get; set; }
        public bool CanReSubmit { get; set; }
    }
}
