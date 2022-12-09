using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Smscdefinition
    {
        public string Smscid { get; set; } = null!;
        public short? PollFrequency { get; set; }
        public string? Description { get; set; }
        public string? TransferMethod { get; set; }
        public string? TransferUser { get; set; }
        public string? TransferPasword { get; set; }
        public short? MaxMessageLength { get; set; }
        public bool? SupportsPriority { get; set; }
        public bool? SupportsExpiry { get; set; }
        public bool? Incoming { get; set; }
        public string? IncomingLayout { get; set; }
        public string? IncomingDirectory { get; set; }
        public int? IncomingTotal { get; set; }
        public bool? Outgoing { get; set; }
        public string? OutgoingLayout { get; set; }
        public string? OutgoingDirectory { get; set; }
        public int? OutgoingTotal { get; set; }
        public string? MerchantCode { get; set; }
    }
}
