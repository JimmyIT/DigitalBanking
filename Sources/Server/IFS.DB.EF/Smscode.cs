using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Smscode
    {
        public string Smscode1 { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? TotalSent { get; set; }
        public int? TotalReceived { get; set; }

        public virtual Smsresponse Smsresponse { get; set; } = null!;
    }
}
