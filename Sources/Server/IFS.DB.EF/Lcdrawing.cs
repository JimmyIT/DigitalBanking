using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Lcdrawing
    {
        public string ClientNumber { get; set; } = null!;
        public string OurRef { get; set; } = null!;
        public string DrawingSequence { get; set; } = null!;
        public string? YourRef { get; set; }
        public string? Status { get; set; }
        public string? Warnings { get; set; }
        public DateTime? DrawingDate { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public string CurrencyCode { get; set; } = null!;
        public decimal BillAmount { get; set; }
        public decimal? AcceptedAmount { get; set; }
        public decimal? OurChargesForOpener { get; set; }
        public decimal? OtherBankForOpener { get; set; }
        public decimal? FreightAndInterest { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? OurChargesForBeneficiary { get; set; }
        public decimal PaymentAmount { get; set; }

        public virtual Lc OurRefNavigation { get; set; } = null!;
    }
}
