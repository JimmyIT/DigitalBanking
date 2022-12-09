using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class AuthorityCode
    {
        public string InternalId { get; set; } = null!;
        public string Pin { get; set; } = null!;
        public string? Keyword1 { get; set; }
        public string? Keyword2 { get; set; }
        public string? Keyword3 { get; set; }
        public string? Keyword4 { get; set; }
        public string? Keyword5 { get; set; }
        public string? Keyword6 { get; set; }
        public string? Keyword7 { get; set; }
        public string? Keyword8 { get; set; }
        public string? Keyword9 { get; set; }
        public string? Keyword10 { get; set; }

        public virtual UserProfile Internal { get; set; } = null!;
    }
}
