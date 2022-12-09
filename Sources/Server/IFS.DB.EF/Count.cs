using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Count
    {
        public DateTime EventDate { get; set; }
        public string Type { get; set; } = null!;
        public double LastAllocatedReference { get; set; }
        public string? ClientNumber { get; set; }
        public string? UserId { get; set; }
    }
}
