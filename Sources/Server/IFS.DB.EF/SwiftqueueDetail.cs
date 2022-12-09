using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class SwiftqueueDetail
    {
        public DateTime DateReceived { get; set; }
        public string MessageType { get; set; } = null!;
        public string Reference { get; set; } = null!;
        public string? Customer { get; set; }
        public DateTime TimeIn { get; set; }
        public bool Printed { get; set; }
        public string OutputFileName { get; set; } = null!;
        public int RecordId { get; set; }
    }
}
