using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Movement
    {
        public short MovementId { get; set; }
        public string AccountNumber { get; set; } = null!;
        public string ClientNumber { get; set; } = null!;
        public string VoucherId { get; set; } = null!;
        public DateTime EntryDate { get; set; }
        public DateTime? ValueDate { get; set; }
        public string? Reference { get; set; }
        public string? Narrative1 { get; set; }
        public string? Narrative2 { get; set; }
        public string? Narrative3 { get; set; }
        public string? Narrative4 { get; set; }
        public string? Narrative5 { get; set; }
        public decimal? Amount { get; set; }
        public string? TransCode { get; set; }
        public bool? BalanceUpdated { get; set; }
        public bool? StatementUpdated { get; set; }
        public string? ChargeCode { get; set; }
        public decimal? ChargeAmount { get; set; }
        public short? MessageId { get; set; }
        public short? Status { get; set; }
        public string? Currency { get; set; }
        public bool? CrossCurrency { get; set; }
    }
}
