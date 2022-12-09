using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Glossary
    {
        public int GlossaryId { get; set; }
        public string Term { get; set; } = null!;
        public string Definition { get; set; } = null!;
        public byte[] MsreplSynctranTs { get; set; } = null!;
    }
}
