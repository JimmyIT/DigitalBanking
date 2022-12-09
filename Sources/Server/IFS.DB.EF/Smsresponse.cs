using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Smsresponse
    {
        public string Smscode { get; set; } = null!;
        public string? ResponseText { get; set; }

        public virtual Smscode SmscodeNavigation { get; set; } = null!;
    }
}
