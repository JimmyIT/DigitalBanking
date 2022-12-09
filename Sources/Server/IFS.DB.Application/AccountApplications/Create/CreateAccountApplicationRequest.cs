using IFS.DB.Application.Domain.Enums;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.Create
{
    public class CreateAccountApplicationRequest
    {
        public Guid ApplicationId { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public AccountApplicationStatusEnum Status { get; set; }
        public string ClientNumber { get; set; }
        public string AccountNumber { get; set; }
        public string AMLtracRefId { get; set; }
        public Guid SessionId { get; set; }
        public string LogonId { get; set; }
        public string MessageContent { get; set; }
        public string ErrorDescription { get; set; }
        public bool CanReSubmit { get; set; }

        public static void ConfigMapping()
        {
            TypeAdapterConfig<CreateAccountApplicationRequest, AccountApplication>
                .NewConfig()
                .Map(dst => dst.UniqueId, src => src.ApplicationId)
                .Map(dst => dst.Status, src => (int)src.Status)
                .Map(dst => dst.AllocatedClientId, src => src.ClientNumber)
                .Map(dst => dst.AllocatedAccountId1, src => src.AccountNumber)
                ;
        }
    }
}
