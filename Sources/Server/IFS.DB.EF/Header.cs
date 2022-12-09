using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Header
    {
        public string RecordType { get; set; } = null!;
        public short? LastAllocatedReference { get; set; }
        public short? StartId { get; set; }
        public short? EndId { get; set; }
        public DateTime? AllocatedOn { get; set; }
    }
}
