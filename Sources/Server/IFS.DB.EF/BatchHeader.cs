using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class BatchHeader
    {
        public BatchHeader()
        {
            BatchItems = new HashSet<BatchItem>();
            TransactionJournals = new HashSet<TransactionJournal>();
        }

        public int BatchId { get; set; }
        public string ClientNumber { get; set; } = null!;
        public string IBankReference { get; set; } = null!;
        public string CustomerReference { get; set; } = null!;
        public string DebitAccount { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public decimal? DebitAmount { get; set; }
        public string DebitNarrative { get; set; } = null!;
        public string? DefaultCreditNarrative { get; set; }
        public string? Password { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime? SubmittedOn { get; set; }
        public DateTime LastProcessed { get; set; }
        public string LastProcessedBy { get; set; } = null!;
        public bool AboutToExpireNotify { get; set; }
        public int? FailedPasswordAttempts { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime ExpiryDate { get; set; }
        public string LogonId { get; set; } = null!;
        public byte[] Timestamp { get; set; } = null!;

        public virtual ICollection<BatchItem> BatchItems { get; set; }
        public virtual ICollection<TransactionJournal> TransactionJournals { get; set; }
    }
}
