using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Charge
    {
        public Charge()
        {
            ChargeHistories = new HashSet<ChargeHistory>();
            ChargeHistoryByClients = new HashSet<ChargeHistoryByClient>();
        }

        public string Smscode { get; set; } = null!;
        public bool? ChargeCr { get; set; }
        public bool? ChargeDr { get; set; }
        public string? BalancingAccount { get; set; }
        public int? ChargeId { get; set; }

        public virtual ChargeDetail? ChargeNavigation { get; set; }
        public virtual ICollection<ChargeHistory> ChargeHistories { get; set; }
        public virtual ICollection<ChargeHistoryByClient> ChargeHistoryByClients { get; set; }
    }
}
