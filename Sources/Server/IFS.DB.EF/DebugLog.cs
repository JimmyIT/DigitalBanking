using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class DebugLog
    {
        public int RecordId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string? RequestReference { get; set; }
        public string? Class { get; set; }
        public string? Function { get; set; }
        public string? LineNumber { get; set; }
        public string? Header { get; set; }
        public string? Details { get; set; }
        public byte[] MsreplSynctranTs { get; set; } = null!;
    }
}
