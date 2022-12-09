using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class BlockedIp
    {
        public string Ip { get; set; } = null!;
        public DateTime BlockedOn { get; set; }
    }
}
