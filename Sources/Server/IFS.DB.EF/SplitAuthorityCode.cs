using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class SplitAuthorityCode
    {
        public int RecordId { get; set; }
        public string InternalId { get; set; } = null!;
        public string HashedChar { get; set; } = null!;
        public short Sequence { get; set; }

        public virtual UserProfile Internal { get; set; } = null!;
    }
}
