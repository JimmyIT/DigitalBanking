using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ChargeDetail
    {
        public ChargeDetail()
        {
            Charges = new HashSet<Charge>();
            RedemptionCharges = new HashSet<RedemptionCharge>();
        }

        public int ChargeId { get; set; }
        public short? Period { get; set; }
        public short? Count { get; set; }
        public bool? ChargeFixed { get; set; }
        public decimal? ChargeAmount { get; set; }
        public decimal? ChargePercent { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        public decimal? TotalCharged { get; set; }

        public virtual ICollection<Charge> Charges { get; set; }
        public virtual ICollection<RedemptionCharge> RedemptionCharges { get; set; }
    }
}
