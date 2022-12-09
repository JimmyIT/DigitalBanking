using IFS.DB.Application.Common.Bankware.ChartOfAccounts;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Results;
using Mapster;

using Domain = IFS.DB.Application.Domain.Bankware.ChartOfAccounts.GetCurrenciesByOnlineCOA;

namespace IFS.DB.Infrastructure.External.Bankware.ChartOfAccounts.GetCurrenciesByOnlineCOA
{
    public class GetCurrenciesByOnlineCOAService : BaseBankwareOpenAPIService, IGetCurrenciesByOnlineCOAService
    {
        public GetCurrenciesByOnlineCOAService(IParameterService parameterSvc)
           : base(parameterSvc)
        { }

        public async Task<ActionResult<IEnumerable<Domain.GetCurrenciesByOnlineCOAResponse>>> DoActionAsync(int chartOfAccountId)
        {
            ActionResult<IEnumerable<Domain.GetCurrenciesByOnlineCOAResponse>> result = new()
            {
                Result = Enumerable.Empty<Domain.GetCurrenciesByOnlineCOAResponse>()
            };

            // Call Bankware API
            string apiPath = BankwareAPIURLConst.EndPoint.OnlineCOA.GetCurrenciesByOnlineCOA.Replace(@"{chartOfAccountId}", chartOfAccountId.ToString());
            ActionResult<IEnumerable<GetCurrenciesByOnlineCOAResponse>> responseObj = await GetAsync<IEnumerable<GetCurrenciesByOnlineCOAResponse>>(apiPath);
            if (!responseObj.IsNotError)
            {
                result.Validation = responseObj.Validation;
                return result;
            }

            result.Result = responseObj.Result.Adapt<IEnumerable<Domain.GetCurrenciesByOnlineCOAResponse>>();

            return result;
        }

    }
}
