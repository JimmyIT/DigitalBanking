using IFS.DB.Application.Domain.Bankware.ChartOfAccounts.GetOnlineCOAByEntityTypeIdForNewApp;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Bankware.ChartOfAccounts
{
    public interface IGetOnlineCOAByEntityTypeIdForNewAppService
    {
        Task<ActionResult<IEnumerable<GetOnlineCOAByEntityTypeIdForNewAppResponse>>> DoActionAsync(int entityTypeId);
    }
}
