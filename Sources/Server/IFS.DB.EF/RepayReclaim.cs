using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class RepayReclaim
    {
        public string ClientId { get; set; } = null!;
        public decimal? MinRepaymentAmount { get; set; }
        public short? RepaymentFrequency { get; set; }
        public string? RepaymentFrequencyPeriod { get; set; }
        public short? RepaymentDelayDays { get; set; }
        public DateTime? LastRepaymentDate { get; set; }
        public decimal? LastRepaymentAmount { get; set; }
        public decimal? MinReclaimAmount { get; set; }
        public short? ReclaimFrequency { get; set; }
        public string? ReclaimFrequencyPeriod { get; set; }
        public short? ReclaimDelayDays { get; set; }
        public DateTime? LastReclaimDate { get; set; }
        public decimal? LastReclaimAmount { get; set; }
        public string? BalanceSweepType { get; set; }
        public decimal? TargetBalance { get; set; }
        public decimal? MinimumBalance { get; set; }

        public virtual Client Client { get; set; } = null!;
    }
}
