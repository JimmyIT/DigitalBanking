using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class TestMessage
    {
        public DateTime Received { get; set; }
        public string? PhoneNo { get; set; }
        public string Message { get; set; } = null!;
        public short NumberToSend { get; set; }
        public string? Smscid { get; set; }
    }
}
