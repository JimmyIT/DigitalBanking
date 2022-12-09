using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Lddeal
    {
        public string ClientNumber { get; set; } = null!;
        public string DealNumber { get; set; } = null!;
        public DateTime EntryDate { get; set; }
        public string DealType { get; set; } = null!;
        public string CurrencyCode { get; set; } = null!;
        public DateTime CommencementDate { get; set; }
        public decimal Principal { get; set; }
        public float InterestRate { get; set; }
        public DateTime MaturityDate { get; set; }
        public decimal Interest { get; set; }
        public string? YourCommencement { get; set; }
        public string? OurCommencement { get; set; }
        public string? YourMaturity { get; set; }
        public string? OurMaturity { get; set; }
        public string? InterestSettlementAccount { get; set; }
        public string ShortDealType { get; set; } = null!;
        public string DealStatus { get; set; } = null!;

        public virtual Client ClientNumberNavigation { get; set; } = null!;
    }
}
