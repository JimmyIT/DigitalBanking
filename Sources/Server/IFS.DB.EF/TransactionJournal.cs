using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class TransactionJournal
    {
        public int TransactionJournalId { get; set; }
        public int TransactionType { get; set; }
        public int JournalItemType { get; set; }
        public DateTime AuditItemDate { get; set; }
        public string ActionedBy { get; set; } = null!;
        public int? CustomerTransferId { get; set; }
        public int? CustomerPaymentId { get; set; }
        public int? PaymentTemplateId { get; set; }
        public string OriginalDetails { get; set; } = null!;
        public string NewDetails { get; set; } = null!;
        public int? BatchId { get; set; }
        public int? SubmittedBatchId { get; set; }

        public virtual BatchHeader? Batch { get; set; }
        public virtual CustomerPayment? CustomerPayment { get; set; }
        public virtual CustomerTransfer? CustomerTransfer { get; set; }
        public virtual PaymentTemplate? PaymentTemplate { get; set; }
    }
}
