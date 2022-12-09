using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class MeterUsageAuditTrail
    {
        public int RecordId { get; set; }
        public double? UnitsLeftAfter { get; set; }
        public int? ItemsPerUnit { get; set; }
        public string? ItemId { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredOn { get; set; }
        public string? Notes { get; set; }
    }
}
