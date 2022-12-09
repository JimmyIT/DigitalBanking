using IFS.DB.Application.Domain.Bankware.ChartOfAccounts.GetOnlineAvailableByEntityType;
using IFS.DB.Application.Domain.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Bankware.ChartOfAccounts
{
    public interface IGetOnlineAvailableCOAByEntityTypeService
    {
        public Task<ActionResult<IEnumerable<GetOnlineAvailableCOAByEntityTypeResponse>>> DoActionAsync(int entityTypeId);
    }
}
