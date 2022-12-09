using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ReleasedBatchHeaderHistory
    {
        public ReleasedBatchHeaderHistory()
        {
            ReleasedBatchItemHistories = new HashSet<ReleasedBatchItemHistory>();
        }

        public int BatchId { get; set; }
        public DateTime SubmittedOn { get; set; }
        public string BatchType { get; set; } = null!;
        public string? ClientNumber { get; set; }
        public string CustomerReference { get; set; } = null!;
        public string ControlAccount { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public decimal Amount { get; set; }
        public string DebitNarrative { get; set; } = null!;
        public string DefaultCreditNarrative { get; set; } = null!;
        public string? Password { get; set; }
        public string SuspenseAccount { get; set; } = null!;
        public DateTime ActionDate { get; set; }
        public bool? ActionDateMessageAcknowledged { get; set; }
        public DateTime? ActionDateMessageAcknowledgedOn { get; set; }
        public string? ActionDateMessageAcknowledgedBy { get; set; }
        public decimal? TotalTransferCommission { get; set; }
        public decimal? TotalPaymentCommsion { get; set; }
        public string IBankReference { get; set; } = null!;
        public DateTime? LastProcessed { get; set; }
        public string? LastProcessedBy { get; set; }
        public int Status { get; set; }
        public bool? AboutToExpireNotify { get; set; }
        public int RequiredSignatures { get; set; }
        public int CurrentSignatures { get; set; }
        public DateTime LastSignedOn { get; set; }
        public string LastSignedBy { get; set; } = null!;
        public string HostReference { get; set; } = null!;
        public DateTime ExpiryDate { get; set; }
        public string LogonId { get; set; } = null!;
        public byte[] Timestamp { get; set; } = null!;

        public virtual ICollection<ReleasedBatchItemHistory> ReleasedBatchItemHistories { get; set; }
    }
}
