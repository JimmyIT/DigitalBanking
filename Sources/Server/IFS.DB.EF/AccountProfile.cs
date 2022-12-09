using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class AccountProfile
    {
        public string LogonId { get; set; } = null!;
        public string AccountNumber { get; set; } = null!;
        public bool Accessible { get; set; }
    }
}
