using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ChargeHistory
    {
        public string Smscode { get; set; } = null!;
        public short Period { get; set; }
        public int? Count { get; set; }
        public decimal? TotalCharged { get; set; }

        public virtual Charge SmscodeNavigation { get; set; } = null!;
    }
}
