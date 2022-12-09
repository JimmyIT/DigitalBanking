using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class RedemptionCharge
    {
        public string VoucherId { get; set; } = null!;
        public decimal Value { get; set; }
        public short TransactionLevel { get; set; }
        public decimal? BandLimit { get; set; }
        public int? ChargeId { get; set; }

        public virtual ChargeDetail? Charge { get; set; }
    }
}
