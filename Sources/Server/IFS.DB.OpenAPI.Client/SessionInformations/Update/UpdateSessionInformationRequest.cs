using IFS.DB.OpenAPI.Client.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.SessionInformations.Update
{
    public class UpdateSessionInformationRequest
    {
        public string InternalId { get; set; }
        public string LogonId { get; set; }
        public string UserId { get; set; }
        public string ClientNumber { get; set; }
        public string AccountNumber { get; set; }
        public string ClientInView { get; set; }
        public string BeneficiaryReference { get; set; }
        public string TransferReference { get; set; }
        public string PaymentReference { get; set; }
        public string UsersInternalID { get; set; }
        public int LogonAttempt { get; set; }
        public string UsersCulture { get; set; }
        public string CardNumber { get; set; }
        public CardStatusEnum? CardStatusCode { get; set; }
        public string PaymentCardLast4Digits { get; set; }
        public string HostedDataID { get; set; }
    }
}
