using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class CustomerTransfer
    {
        public CustomerTransfer()
        {
            TransactionJournals = new HashSet<TransactionJournal>();
        }

        public int CustomerTransferId { get; set; }
        public string CreditCurrency { get; set; } = null!;
        public decimal CreditAmount { get; set; }
        public string CreditAccount { get; set; } = null!;
        public string? CreditNarrative { get; set; }
        public bool? OwnAccount { get; set; }
        public decimal DebitAmount { get; set; }
        public string DebitAccount { get; set; } = null!;
        public string? DebitNarrative { get; set; }
        public decimal ExchangeRate { get; set; }
        public int Status { get; set; }
        public string? ClientNumber { get; set; }
        public string? HostReference { get; set; }
        public int RequiredSignatures { get; set; }
        public int CurrentSignatures { get; set; }
        public string LogonId { get; set; } = null!;
        public string IBankReference { get; set; } = null!;
        public DateTime ValueDate { get; set; }
        public int PendingOperation { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool AboutToExpireNotify { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public byte[] Timestamp { get; set; } = null!;
        public bool? IsFromMbank { get; set; }

        public virtual ICollection<TransactionJournal> TransactionJournals { get; set; }
    }
}
