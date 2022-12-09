using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Domain.TokenSale.KYC.Approve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.TokenSale.KYC
{
    public interface IApproveKYCService
    {
        Task<ActionResult<bool>> DoActionAsync(ApproveKYCRequest kyc);
    }
}
