using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class SmstrafficCount
    {
        public string ClientId { get; set; } = null!;
        public string Smscode { get; set; } = null!;
        public int? SentCount { get; set; }
        public short? ReceivedCount { get; set; }
    }
}
