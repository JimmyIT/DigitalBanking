using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Holiday
    {
        public DateTime Date { get; set; }
        public string Currency { get; set; } = null!;
    }
}
