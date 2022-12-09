using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class XauthorityCode
    {
        public string UniqueId { get; set; } = null!;
        public string? RequestReference { get; set; }
        public string? CustomersReference { get; set; }
        public string? ClientNumber { get; set; }
        public int? NumberofAuthorisationAttempts { get; set; }
        public string? Status { get; set; }
        public string? InternalId { get; set; }
        public string Pin { get; set; } = null!;
        public string? CurrentKeyword1 { get; set; }
        public string? CurrentKeyword2 { get; set; }
        public string? CurrentKeyword3 { get; set; }
        public string? CurrentKeyword4 { get; set; }
        public string? CurrentKeyword5 { get; set; }
        public string? CurrentKeyword6 { get; set; }
        public string? CurrentKeyword7 { get; set; }
        public string? CurrentKeyword8 { get; set; }
        public string? CurrentKeyword9 { get; set; }
        public string? CurrentKeyword10 { get; set; }
        public string? NewKeyword1 { get; set; }
        public string? NewKeyword2 { get; set; }
        public string? NewKeyword3 { get; set; }
        public string? NewKeyword4 { get; set; }
        public string? NewKeyword5 { get; set; }
        public string? NewKeyword6 { get; set; }
        public string? NewKeyword7 { get; set; }
        public string? NewKeyword8 { get; set; }
        public string? NewKeyword9 { get; set; }
        public string? NewKeyword10 { get; set; }
    }
}
