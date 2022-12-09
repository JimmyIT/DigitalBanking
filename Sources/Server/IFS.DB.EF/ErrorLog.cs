using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ErrorLog
    {
        public int ErrorNumber { get; set; }
        public string ClientNumber { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string? PageBeingViewed { get; set; }
        public string? RequestBeingMade { get; set; }
        public string DetailedDescription { get; set; } = null!;
        public byte[] MsreplSynctranTs { get; set; } = null!;
    }
}
