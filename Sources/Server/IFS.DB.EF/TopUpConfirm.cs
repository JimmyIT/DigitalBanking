using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class TopUpConfirm
    {
        public int RecordId { get; set; }
        public string? TopUpConfirmRequestType { get; set; }
        public string? TopUpConfirmRequestCode { get; set; }
        public string? TerminalId { get; set; }
        public string? MessageNo { get; set; }
        public string? ServiceProviderName { get; set; }
        public string? TransactionId { get; set; }
        public DateTime? TimestampValue { get; set; }
        public string? PaymentType { get; set; }
    }
}
