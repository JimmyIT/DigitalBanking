using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class SystemDate
    {
        public DateTime ExtractDate { get; set; }
        public DateTime? NextProcessingDate { get; set; }
    }
}
