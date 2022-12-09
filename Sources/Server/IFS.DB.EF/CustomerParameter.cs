using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class CustomerParameter
    {
        public string? LimitsCurrency { get; set; }
        public string LogonId { get; set; } = null!;
    }
}
