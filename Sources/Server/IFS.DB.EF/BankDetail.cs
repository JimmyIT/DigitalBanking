using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class BankDetail
    {
        public string ClientId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string AccountNumber { get; set; } = null!;
        public string? ClearingCode { get; set; }
        public string? Address { get; set; }

        public virtual Client Client { get; set; } = null!;
    }
}
