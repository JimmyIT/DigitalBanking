using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class CustomerPayment
    {
        public CustomerPayment()
        {
            TransactionJournals = new HashSet<TransactionJournal>();
        }

        public int CustomerPaymentId { get; set; }
        public string ClientNumber { get; set; } = null!;
        public string DebitAccount { get; set; } = null!;
        public int Status { get; set; }
        public string? HostReference { get; set; }
        public string IBankReference { get; set; } = null!;
        public DateTime ValueDate { get; set; }
        public string CreditCurrency { get; set; } = null!;
        public decimal DebitAmount { get; set; }
        public int RequiredSignatures { get; set; }
        public string PaymentTemplateDetails { get; set; } = null!;
        public int PaymentTemplateId { get; set; }
        public string DebitNarrative { get; set; } = null!;
        public string BeneficiaryReference { get; set; } = null!;
        public int PaymentType { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public int CurrentSignatures { get; set; }
        public string LogonId { get; set; } = null!;
        public int PendingOperation { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool AboutToExpireNotify { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public byte[] Timestamp { get; set; } = null!;
        public bool? IsFromMbank { get; set; }

        public virtual PaymentTemplate PaymentTemplate { get; set; } = null!;
        public virtual PaymentType PaymentTypeNavigation { get; set; } = null!;
        public virtual ICollection<TransactionJournal> TransactionJournals { get; set; }
    }
}
