using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class SmsshortCode
    {
        public short ProcessOrder { get; set; }
        public string ShortCodeContent { get; set; } = null!;
        public string Smscode { get; set; } = null!;
        public bool CanConfirm { get; set; }

        public virtual Smsrule SmscodeNavigation { get; set; } = null!;
    }
}
