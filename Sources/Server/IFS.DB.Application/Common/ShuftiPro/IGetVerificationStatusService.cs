using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Domain.ShuftiPro.GetVerificationStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.ShuftiPro
{
    public interface IGetVerificationStatusService
    {
        Task<ActionResult<GetVerificationStatusResponse>> DoActionAsync(string reference);
    }
}
