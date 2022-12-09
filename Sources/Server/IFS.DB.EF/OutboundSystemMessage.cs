using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class OutboundSystemMessage
    {
        public int RecordId { get; set; }
        public string Message { get; set; } = null!;
        public bool Processed { get; set; }
        public string OutputFileName { get; set; } = null!;
        public DateTime CreationDate { get; set; }
    }
}
