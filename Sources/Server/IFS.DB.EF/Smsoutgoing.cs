using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Smsoutgoing
    {
        public int MessageId { get; set; }
        public string? MessageRef { get; set; }
        public short? Status { get; set; }
        public string? PhoneNo { get; set; }
        public string? Message { get; set; }
        public string? Smscid { get; set; }
        public DateTime? Sent { get; set; }
        public string? MessagePriority { get; set; }
        public DateTime? MessageExpiry { get; set; }
    }
}
