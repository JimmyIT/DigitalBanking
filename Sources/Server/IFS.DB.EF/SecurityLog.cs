using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class SecurityLog
    {
        public string UniqueId { get; set; } = null!;
        public string RequestReference { get; set; } = null!;
        public string CustomersReference { get; set; } = null!;
        public string? ClientNumber { get; set; }
        public int? NumberofAuthorisationAttempts { get; set; }
        public string? Status { get; set; }
        public string LogonId { get; set; } = null!;
        public string? UserId { get; set; }
        public DateTime? Timestamp { get; set; }
        public bool RememberUserName { get; set; }
        public bool FirstTime { get; set; }
    }
}
