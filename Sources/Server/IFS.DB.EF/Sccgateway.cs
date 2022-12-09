using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Sccgateway
    {
        public string SystemId { get; set; } = null!;
        public string? SccstoreId { get; set; }
        public string? SccbranchId { get; set; }
        public string? SccterminalId { get; set; }
        public string? SccoperatorId { get; set; }
        public string? CardFirstCharacter { get; set; }
        public string? CardSeparatorCharacter { get; set; }
        public string? TransactionIdprefix { get; set; }
        public short? Timeout { get; set; }
        public short? PollFrequency { get; set; }

        public virtual SmssystemDefault System { get; set; } = null!;
    }
}
