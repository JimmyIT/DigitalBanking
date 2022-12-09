using IFS.DB.Application.Domain.Bankware.ChartOfAccounts.GetCurrenciesByOnlineCOA;
using IFS.DB.Application.Domain.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Bankware.ChartOfAccounts
{
    public interface IGetCurrenciesByOnlineCOAService
    {
        public Task<ActionResult<IEnumerable<GetCurrenciesByOnlineCOAResponse>>> DoActionAsync(int entityTypeId);
    }
}
