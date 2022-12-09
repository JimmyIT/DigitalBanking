using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class TopUpRequest
    {
        public int RecordId { get; set; }
        public string? TopUpRequestType { get; set; }
        public string? TerminalId { get; set; }
        public string? MessageNo { get; set; }
        public string? BranchNo { get; set; }
        public string? CardDetails { get; set; }
        public string? CardDetailsInput { get; set; }
        public string? BarCodeEan { get; set; }
        public decimal? Amount { get; set; }
        public string? AmountCurrency { get; set; }
        public string? ReferenceId { get; set; }
        public DateTime? TimeStampValue { get; set; }
        public string? PaymentType { get; set; }
        public string? ProductId { get; set; }
        public string? OperatorId { get; set; }
        public string? SupplementaryReceiptTextCode { get; set; }
    }
}
