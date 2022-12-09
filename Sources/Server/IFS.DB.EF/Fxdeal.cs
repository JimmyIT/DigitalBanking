using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Fxdeal
    {
        public string ClientNumber { get; set; } = null!;
        public string DealNumber { get; set; } = null!;
        public DateTime EntryDate { get; set; }
        public string BoughtStatus { get; set; } = null!;
        public string BoughtCurrency { get; set; } = null!;
        public DateTime? BoughtOptionDate { get; set; }
        public DateTime BoughtValueDate { get; set; }
        public decimal BoughtAmount { get; set; }
        public decimal? BoughtCommission { get; set; }
        public decimal? BoughtCharges { get; set; }
        public decimal ExchangeRate { get; set; }
        public string SoldStatus { get; set; } = null!;
        public string SoldCurrency { get; set; } = null!;
        public DateTime? SoldOptionDate { get; set; }
        public DateTime SoldValueDate { get; set; }
        public decimal SoldAmount { get; set; }
        public decimal? SoldCommission { get; set; }
        public decimal? SoldCharges { get; set; }
        public string? YourReceive { get; set; }
        public string? OurPay { get; set; }
        public string? YourPay { get; set; }
        public string? OurReceive { get; set; }

        public virtual Client ClientNumberNavigation { get; set; } = null!;
    }
}
