using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Collection
    {
        public string ClientNumber { get; set; } = null!;
        public string OurRef { get; set; } = null!;
        public string? YourRef { get; set; }
        public string CurrencyCode { get; set; } = null!;
        public decimal BillAmount { get; set; }
        public float? DiscountRate { get; set; }
        public DateTime? DiscountDate { get; set; }
        public decimal? DiscountInterest { get; set; }
        public string? Tenor { get; set; }
        public string? Term { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? Status { get; set; }
        public string? Warnings { get; set; }
        public string? DraweeName { get; set; }
        public string? DraweeDetails { get; set; }
        public string? OurPay { get; set; }
        public string? YourReceive { get; set; }
        public string? DrawerCharge1Description { get; set; }
        public decimal? DrawerCharge1Amount { get; set; }
        public string? DrawerCharge2Description { get; set; }
        public decimal? DrawerCharge2Amount { get; set; }
        public string? DrawerCharge3Description { get; set; }
        public decimal? DrawerCharge3Amount { get; set; }
        public string? DrawerCharge4Description { get; set; }
        public decimal? DrawerCharge4Amount { get; set; }
        public string? DrawerCharge5Description { get; set; }
        public decimal? DrawerCharge5Amount { get; set; }
        public string? DraweeCharge1Description { get; set; }
        public decimal? DraweeCharge1Amount { get; set; }
        public string? DraweeCharge2Description { get; set; }
        public decimal? DraweeCharge2Amount { get; set; }
        public string? DraweeCharge3Description { get; set; }
        public decimal? DraweeCharge3Amount { get; set; }
        public string? DraweeCharge4Description { get; set; }
        public decimal? DraweeCharge4Amount { get; set; }
        public string? DraweeCharge5Description { get; set; }
        public decimal? DraweeCharge5Amount { get; set; }

        public virtual Client ClientNumberNavigation { get; set; } = null!;
    }
}
