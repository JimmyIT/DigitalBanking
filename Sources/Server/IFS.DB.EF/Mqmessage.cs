using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Mqmessage
    {
        public Mqmessage()
        {
            MqmessageQueues = new HashSet<MqmessageQueue>();
            MquserActionLogs = new HashSet<MquserActionLog>();
        }

        public int MessageId { get; set; }
        public string? Reference { get; set; }
        public string? OriginalReference { get; set; }
        public int MessageType { get; set; }
        public int? ActionType { get; set; }
        public string? AccountNumber { get; set; }
        public string? ClientNumber { get; set; }
        public string? AdditionalInfo1 { get; set; }
        public string? AdditionalInfo2 { get; set; }
        public string Direction { get; set; } = null!;
        public string MessageContent { get; set; } = null!;
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public byte[] Cctimestamp { get; set; } = null!;
        public bool? Processed { get; set; }
        public string? OrderId { get; set; }
        public string? ApprovalCode { get; set; }
        public string? TransactionState { get; set; }
        public string? CreditCard { get; set; }
        public string? CreditCardType { get; set; }
        public string? CardNumber { get; set; }
        public decimal? LoadUnloadAmount { get; set; }
        public string? Currency { get; set; }
        public string? TxnType { get; set; }
        public DateTime? TxnDateTime { get; set; }
        public string? TxnNarrative { get; set; }
        public string? LogonId { get; set; }
        public string? FailReason { get; set; }
        public string? IpgTransactionId { get; set; }

        public virtual ICollection<MqmessageQueue> MqmessageQueues { get; set; }
        public virtual ICollection<MquserActionLog> MquserActionLogs { get; set; }
    }
}
