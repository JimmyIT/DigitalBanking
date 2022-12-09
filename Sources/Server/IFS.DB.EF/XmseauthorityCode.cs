using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class XmseauthorityCode
    {
        public int Status { get; set; }
        public string AmendedBy { get; set; } = null!;
        public DateTime AmendedOn { get; set; }
        public string LogonId { get; set; } = null!;
        public string AuthorityCode { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public string HashValue { get; set; } = null!;
    }
}
