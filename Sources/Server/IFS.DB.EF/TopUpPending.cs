using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class TopUpPending
    {
        public int RecordId { get; set; }
        public string MobilePhoneNo { get; set; } = null!;
        public decimal Amount { get; set; }
        public short? Status { get; set; }
        public bool? TopUpRequest { get; set; }
        public bool? TopUpConfirm { get; set; }
        public bool? TopUpResponse { get; set; }
        public bool? TopUpConfirmResponse { get; set; }
        public bool? Cancelled { get; set; }
        public bool? Completed { get; set; }
        public string? MessageNo { get; set; }
        public DateTime? TopUpRequestTime { get; set; }
        public DateTime? TopUpResponseTime { get; set; }
        public DateTime? TopUpConfirmTime { get; set; }
        public DateTime? TopUpConfirmResponseTime { get; set; }
        public string? Operator { get; set; }
    }
}
