using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class XiMailBox
    {
        public string UniqueId { get; set; } = null!;
        public string? RequestReference { get; set; }
        public string CustomersReference { get; set; } = null!;
        public string? ClientNumber { get; set; }
        public int? NumberofAuthorisationAttempts { get; set; }
        public string Status { get; set; } = null!;
        public string InternalId { get; set; } = null!;
        public int MessageId { get; set; }
        public string Type { get; set; } = null!;
        public DateTime? Date { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Cc { get; set; }
        public string? Priority { get; set; }
        public string Subject { get; set; } = null!;
        public string? Body { get; set; }
        public bool Read { get; set; }
        public bool RepliedTo { get; set; }
        public bool Deleted { get; set; }
        public int? OriginalMessageId { get; set; }
        public byte[] MsreplSynctranTs { get; set; } = null!;
    }
}
