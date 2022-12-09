using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Customers.GetById
{
    public class GetCustomerByIdResponse
    {
        public string LogonId { get; set; }
        public string ClientNumber { get; set; }
        public string ClientType { get; set; }
        public string Language { get; set; }
        public bool Internal { get; set; }
        public string HostBranchCustomer { get; set; }
        public bool Activated { get; set; }
        public string CountryCode { get; set; }
        public bool? BulkReleaseTransactions { get; set; }
        public int SignaturesRequiredForCancellation { get; set; }
        public bool? PaymentsInBulk { get; set; }
        public bool? CanUploadPaymentFiles { get; set; }
        public bool? PaymentFileCollection { get; set; }
        public string PaymentFileCurrency { get; set; }
        public bool? IsTouristCard { get; set; }
    }
}
