using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Audit
    {
        public string TransactionUi { get; set; } = null!;
        public string AuditType { get; set; } = null!;
        public string? CustomerId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TransactionType { get; set; }
        public string? TransactionDetails { get; set; }
        public short? Status { get; set; }
    }
}
