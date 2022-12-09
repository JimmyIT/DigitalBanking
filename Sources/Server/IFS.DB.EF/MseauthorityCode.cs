using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class MseauthorityCode
    {
        public string LogonId { get; set; } = null!;
        public string AuthorityCode { get; set; } = null!;
        public string Salt { get; set; } = null!;

        public virtual IBankCustomer Logon { get; set; } = null!;
    }
}
