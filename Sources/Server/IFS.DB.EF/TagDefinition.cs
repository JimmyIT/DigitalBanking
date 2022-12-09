using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class TagDefinition
    {
        public string Tag { get; set; } = null!;
        public string? TagOption { get; set; }
        public string? Description { get; set; }
        public int? Subfield { get; set; }
        public string? SubfieldDescription { get; set; }
        public string? PermittedValues { get; set; }
        public string? SubfieldDelimiter { get; set; }
        public string TagType { get; set; } = null!;
        public int RecordId { get; set; }
        public byte[] MsreplSynctranTs { get; set; } = null!;
    }
}
