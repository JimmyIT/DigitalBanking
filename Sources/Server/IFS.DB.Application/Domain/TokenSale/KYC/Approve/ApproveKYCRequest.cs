using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.TokenSale.KYC.Approve
{
    public class ApproveKYCRequest
    {
        public int LinkId { get; set; }
        public int RequestId { get; set; }
        public Guid AMLRefId { get; set; }
        public string Reference { get; set; }
    }
}
