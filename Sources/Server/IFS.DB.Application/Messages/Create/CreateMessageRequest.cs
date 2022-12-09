using IFS.DB.Application.Domain.Enums;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Messages.Create
{
    public class CreateMessageRequest
    {
        public string Reference { get; set; }
        public string OriginalReference { get; set; }
        public MessageTypeEnum MessageType { get; set; }
        public string AccountNumber { get; set; }
        public string ClientNumber { get; set; }
        public string AdditionalInfo1 { get; set; }
        public string AdditionalInfo2 { get; set; }
        public string Direction { get; set; }
        public string MessageContent { get; set; }
        public string OrderId { get; set; }
        public string ApprovalCode { get; set; }
        public string TransactionState { get; set; }
        public string CreditCard { get; set; }
        public string CreditCardType { get; set; }
        public string CardNumber { get; set; }
        public decimal? LoadUnloadAmount { get; set; }
        public string Currency { get; set; }
        public DateTime? TxnDateTime { get; set; }
        public string TxnNarrative { get; set; }
        public string LogonId { get; set; }
        public string FailReason { get; set; }
        public string IpgTransactionId { get; set; }
        public string Note { get; set; }

        public static void ConfigMapping()
        {
            TypeAdapterConfig<Mqmessage, CreateMessageRequest>
                .NewConfig()
                .Map(dst => dst.MessageType, src => (int)src.MessageType)
                ;
        }
    }
}
