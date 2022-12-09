using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Bankware.ChartOfAccounts;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Results;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BWDomain = IFS.DB.Application.Domain.Bankware.ChartOfAccounts.GetCurrenciesByOnlineCOA;

namespace IFS.DB.Application.ChartOfAccounts.GetCurrenciesByOnlineCOA
{
    public interface IGetCurrenciesByOnlineCOAHandler : IBaseHandler
    {
        public Task<ActionResult<IEnumerable<GetCurrenciesByOnlineCOAResponse>>> DoActionAsync(int chartOfAccountId);
    }

    public class GetCurrenciesByOnlineCOAHandler : BaseHandler, IGetCurrenciesByOnlineCOAHandler
    {
        private readonly IGetCurrenciesByOnlineCOAService _GetCurrenciesOnlineAvailableByCOAIDService;
        public GetCurrenciesByOnlineCOAHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IGetCurrenciesByOnlineCOAService getCurrenciesOnlineAvailableByCOAIDService)
            : base(errorMessageSvc, headerValidator)
        {
            _GetCurrenciesOnlineAvailableByCOAIDService = getCurrenciesOnlineAvailableByCOAIDService;
        }

        public async Task<ActionResult<IEnumerable<GetCurrenciesByOnlineCOAResponse>>> DoActionAsync(int chartOfAccountId)
        {
            ActionResult<IEnumerable<GetCurrenciesByOnlineCOAResponse>> result = new()
            {
                Result = Enumerable.Empty<GetCurrenciesByOnlineCOAResponse>()
            };

            ActionResult<IEnumerable<BWDomain.GetCurrenciesByOnlineCOAResponse>> responseResult = await _GetCurrenciesOnlineAvailableByCOAIDService.DoActionAsync(chartOfAccountId);
            if (responseResult != null)
            {
                result.Result = responseResult.Result.Adapt<IEnumerable<GetCurrenciesByOnlineCOAResponse>>();
            }
            return result;
        }
    }
}
