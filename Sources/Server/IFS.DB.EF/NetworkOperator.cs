using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class NetworkOperator
    {
        public string ClientId { get; set; } = null!;
        public bool VirtualOperator { get; set; }
        public int? ActualOperatorId { get; set; }

        public virtual Client Client { get; set; } = null!;
    }
}
