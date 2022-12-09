using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Utilities;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.GetClearDown
{
    public class GetAccountApplicationClearDownResponse
    {
        public Guid ApplicationId { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public AccountApplicationStatusEnum Status { get; set; }
        public string ClientNumber { get; set; }
        public string AccountNumber { get; set; }
        public string AMLtracRefId { get; set; }
        public string ShuftiProRefId { get; set; }
        public string ShuftiProVerificationURL { get; set; }
        public DateTime? ShuftiProURLExpiryDate { get; set; }
        public string KYCRefId { get; set; }
        public string BackCallBackURL { get; set; }
        public string SubmitCallBackURL { get; set; }
        public string AdditionalDocumentRequirement { get; set; }
        public int LatestStep { get; set; }
        public Guid SessionId { get; set; }
        public string LogonId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string MessageContent { get; set; }
        public string ErrorDescription { get; set; }
        public bool CanReSubmit { get; set; }

        public static void ConfigMapping()
        {
            TypeAdapterConfig<AccountApplication, GetAccountApplicationClearDownResponse>
                .NewConfig()
                .Map(dst => dst.ApplicationId, src => src.UniqueId)
                .Map(dst => dst.Status, src => (AccountApplicationStatusEnum)src.Status)
                .Map(dst => dst.ClientNumber, src => src.AllocatedClientId)
                .Map(dst => dst.AccountNumber, src => src.AllocatedAccountId1)
                ;
        }
    }
}
