using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Statement
    {
        public string AccountNumber { get; set; } = null!;
        public DateTime EntryDate { get; set; }
        public string? Reference { get; set; }
        public DateTime? ValueDate { get; set; }
        public string? Narrative1 { get; set; }
        public string? Narrative2 { get; set; }
        public string? Narrative3 { get; set; }
        public string? Narrative4 { get; set; }
        public string? Narrative5 { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public string? Expanded { get; set; }
        public string? ProductCode { get; set; }
        public string? KeyValue { get; set; }
        public bool? ImportedToday { get; set; }
        public int StatementId { get; set; }
        public string? Last4CardDigits { get; set; }
        public int? DebitCardType { get; set; }

        public virtual Account AccountNumberNavigation { get; set; } = null!;
    }
}
