using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Nanpcode
    {
        public short SubDialingCode { get; set; }
        public string? CountryCode { get; set; }
        public string? Description { get; set; }
    }
}
