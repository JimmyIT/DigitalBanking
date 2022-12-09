using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class TopUpResponse
    {
        public int RecordId { get; set; }
        public string? TopUpResponseType { get; set; }
        public string? TopUpResponseConfirm { get; set; }
        public string? TerminalId { get; set; }
        public string? MessageNo { get; set; }
        public string? ResponseCodeValue { get; set; }
        public string? StoreId { get; set; }
        public string? TransactionId { get; set; }
        public decimal? Amount { get; set; }
        public string? AmountCurrency { get; set; }
        public string? TopUpText { get; set; }
        public string? ServiceProviderName { get; set; }
        public string? ProductName { get; set; }
        public string? MsisdnNo { get; set; }
        public string? NewBalanceValue { get; set; }
        public string? ServiceBalanceValue { get; set; }
        public string? HelpdeskNo { get; set; }
        public string? RetryTime { get; set; }
        public string? ActivationCode { get; set; }
        public string? ActivationCodeSerialNo { get; set; }
        public string? ActivationCodeBatchNo { get; set; }
        public string? GenericMessage { get; set; }
        public string? TillMessage { get; set; }
        public string? CustomerMessage { get; set; }
    }
}
