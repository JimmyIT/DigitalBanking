using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class MessageDefinition
    {
        public string MessageNumber { get; set; } = null!;
        public short FieldNumber { get; set; }
        public string TagType { get; set; } = null!;
        public string Tag { get; set; } = null!;
        public string? TagOption { get; set; }
        public int? Occurrance { get; set; }
        public bool Mandatory { get; set; }
        public bool? IncludeInSwiftmessage { get; set; }
        public int RecordId { get; set; }
        public byte[] MsreplSynctranTs { get; set; } = null!;
    }
}
