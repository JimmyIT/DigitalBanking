using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Customers.CreateSSE
{
    public class CreateSSECustomerRequest
    {
        public string LogonID { get; set; }
        public string ClientNumber { get; set; }
        public string CustomerType { get; set; }
        public string Email { get; set; }
        public string MobilePhoneNumberIDD { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string PIN { get; set; }
        public string CountryCode { get; set; }
        public string DefaultLanguage { get; set; }
        public string PaymentCurrency { get; set; }
        public bool BulkPayment { get; set; }
        public bool BulkRelease { get; set; }
        public bool Activated { get; set; }
        public bool UploadPaymentFile { get; set; }
        public bool UploadPaymentCollection { get; set; }
    }
}
