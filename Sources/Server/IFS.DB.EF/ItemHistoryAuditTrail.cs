using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ItemHistoryAuditTrail
    {
        public decimal RecordId { get; set; }
        public string UniqueIdofItem { get; set; } = null!;
        public int Action { get; set; }
        public string RequestReference { get; set; } = null!;
        public int Sequence { get; set; }
        public string? InternalId { get; set; }
        public string? ItemDetails { get; set; }
        public double? MaximumEntryAmount { get; set; }
        public bool UnlimitedEntry { get; set; }
        public double? MaximumSigningAmount { get; set; }
        public bool UnlimitedSigning { get; set; }
        public bool SignOwn { get; set; }
        public DateTime? AuditRecordCreatedOn { get; set; }
        public int ItemHistoryAuditTrailId { get; set; }
    }
}
