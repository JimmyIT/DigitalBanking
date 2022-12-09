using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Lc
    {
        public Lc()
        {
            Lcdrawings = new HashSet<Lcdrawing>();
        }

        public string ClientNumber { get; set; } = null!;
        public string OurRef { get; set; } = null!;
        public string? YourRef { get; set; }
        public string CurrencyCode { get; set; } = null!;
        public decimal Lcamount { get; set; }
        public string? TolerancePct { get; set; }
        public decimal? Tolerance { get; set; }
        public decimal? TotalContingent { get; set; }
        public decimal? TotalDrawn { get; set; }
        public decimal? UndrawnAmount { get; set; }
        public DateTime? OpenedDate { get; set; }
        public DateTime? LastShipmentDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string? PartShipment { get; set; }
        public string? Warnings { get; set; }
        public string? Term { get; set; }
        public string? TermEvent { get; set; }
        public string BeneficiaryName { get; set; } = null!;
        public string? BeneficiaryDetails { get; set; }
        public string? ConsigneeName { get; set; }
        public string? ConsigneeDetails { get; set; }
        public string? DrawingSequence { get; set; }

        public virtual Client ClientNumberNavigation { get; set; } = null!;
        public virtual ICollection<Lcdrawing> Lcdrawings { get; set; }
    }
}
