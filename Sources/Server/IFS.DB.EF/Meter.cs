using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Meter
    {
        public int MeterId { get; set; }
        public double? UnitsLeft { get; set; }
        public double? UnitsUsed { get; set; }
        public DateTime? LastRecharged { get; set; }
    }
}
