using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Domain.ShuftiPro.GetVerificationURL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.ShuftiPro
{
    public interface IGetVerificationURLService
    {
        Task<ActionResult<GetVerificationURLResponse>> DoActionAsync(GetVerificationURLRequest model);
    }
}
