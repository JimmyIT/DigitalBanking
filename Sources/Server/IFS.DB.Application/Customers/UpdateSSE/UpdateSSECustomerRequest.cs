using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Customers.UpdateSSE
{
    public class UpdateSSECustomerRequest
    {
        public string LogonID { get; set; }
        public string Email { get; set; }
        public bool? Activated { get; set; }
        public bool? BulkRelease { get; set; }
        public bool? BulkPayment { get; set; }
        public bool? ResetKeyword { get; set; }
        public string PaymentCurrency { get; set; }
        public bool? UploadPaymentFile { get; set; }
        public bool? UploadPaymentCollection { get; set; }
        public string Phone { get; set; }
        public string MobilePhoneNumberIDD { get; set; }
    }
}
