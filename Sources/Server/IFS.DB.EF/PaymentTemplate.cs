using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class PaymentTemplate
    {
        public PaymentTemplate()
        {
            BatchItems = new HashSet<BatchItem>();
            CustomerPayments = new HashSet<CustomerPayment>();
            ReleasedBatchItemHistories = new HashSet<ReleasedBatchItemHistory>();
            TransactionJournals = new HashSet<TransactionJournal>();
        }

        public int PaymentTemplateId { get; set; }
        public string? ClientNumber { get; set; }
        public string? DebitAccount { get; set; }
        public string? HostReference { get; set; }
        public int Status { get; set; }
        public int? ClientGroupId { get; set; }
        public bool? SinglePaymentTemplate { get; set; }
        public string PaymentTemplateDetails { get; set; } = null!;
        public string CreditCurrency { get; set; } = null!;
        public string? DebitNarrative { get; set; }
        public int RequiredSignatures { get; set; }
        public string? BeneficiaryName { get; set; }
        public int? CurrentSignatures { get; set; }
        public string LogonId { get; set; } = null!;
        public int PaymentTemplateType { get; set; }
        public string IBankReference { get; set; } = null!;
        public string? BeneficiaryReference { get; set; }
        public int PendingOperation { get; set; }
        public string CustomerReference { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public byte[] Timestamp { get; set; } = null!;

        public virtual ICollection<BatchItem> BatchItems { get; set; }
        public virtual ICollection<CustomerPayment> CustomerPayments { get; set; }
        public virtual ICollection<ReleasedBatchItemHistory> ReleasedBatchItemHistories { get; set; }
        public virtual ICollection<TransactionJournal> TransactionJournals { get; set; }
    }
}
