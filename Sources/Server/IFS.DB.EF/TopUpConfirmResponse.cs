using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class TopUpConfirmResponse
    {
        public int RecordId { get; set; }
        public string? TopUpConfirmResponseType { get; set; }
        public string? TopUpConfirmResponseCode { get; set; }
        public string? TerminalId { get; set; }
        public string? MessageNo { get; set; }
        public string? VoidTransactionId { get; set; }
    }
}
