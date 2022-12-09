using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ChargeHistoryByClient
    {
        public string ClientId { get; set; } = null!;
        public string Smscode { get; set; } = null!;
        public short Period { get; set; }
        public int? Count { get; set; }
        public decimal? TotalCharged { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Charge SmscodeNavigation { get; set; } = null!;
    }
}
