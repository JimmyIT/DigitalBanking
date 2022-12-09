using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class CardOutgoing
    {
        public string MessageId { get; set; } = null!;
        public string FunctionId { get; set; } = null!;
        public short Status { get; set; }
        public string CardId { get; set; } = null!;
        public int Amount { get; set; }
        public string TransactionType { get; set; } = null!;
        public string CurrencyCode { get; set; } = null!;
        public int? SettlementAmount { get; set; }
        public string? SettlementCurrencyCode { get; set; }
        public string? TransactionDescription { get; set; }
        public string? OutParameter1 { get; set; }
        public string? OutParameter2 { get; set; }
        public string? OutParameter3 { get; set; }
        public string? OutParameter4 { get; set; }
        public string? OutParameter5 { get; set; }
    }
}
