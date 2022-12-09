using IFS.DB.Application.Domain.Enums;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.SessionInformations.GetById
{
    public class GetSessionInformationByIdResponse
    {
        public string SessionId { get; set; }
        public string InternalId { get; set; }
        public string LogonId { get; set; }
        public string UserId { get; set; }
        public string ClientNumber { get; set; }
        public string AccountNumber { get; set; }
        public string ClientInView { get; set; }
        public string BeneficiaryReference { get; set; }
        public string TransferReference { get; set; }
        public string PaymentReference { get; set; }
        public string UsersInternalID { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string IP { get; set; }
        public int LogonAttempt { get; set; }
        public string UsersCulture { get; set; }
        public string CardNumber { get; set; }
        public CardStatusEnum? CardStatusCode { get; set; }
        public string PaymentCardLast4Digits { get; set; }
        public string HostedDataID { get; set; }

        public static void ConfigMapping()
        {
            TypeAdapterConfig<SessionInformation, GetSessionInformationByIdResponse>
                .NewConfig()
                .Map(dst => dst.ExpiryDate, src => src.Expiry)
                .Map(dst => dst.CardStatusCode, src => (CardStatusEnum)src.CardStatusCode)
                ;
        }
    }
}
