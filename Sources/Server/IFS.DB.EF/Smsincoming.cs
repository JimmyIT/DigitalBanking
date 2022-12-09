using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Smsincoming
    {
        public int MessageId { get; set; }
        public string? MessageRef { get; set; }
        public DateTime? Received { get; set; }
        public string? PhoneNo { get; set; }
        public string? Message { get; set; }
        public short? Status { get; set; }
        public string? Smscid { get; set; }
        public string? ConfirmationCode { get; set; }
        public string? Confirmer { get; set; }
        public string? MatchedSmscode { get; set; }
    }
}
