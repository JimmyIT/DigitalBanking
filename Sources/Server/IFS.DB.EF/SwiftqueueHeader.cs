using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class SwiftqueueHeader
    {
        public DateTime DateReceived { get; set; }
        public string MessageType { get; set; } = null!;
        public int TotalIn { get; set; }
        public int TotalPrinted { get; set; }
        public int RecordId { get; set; }
    }
}
