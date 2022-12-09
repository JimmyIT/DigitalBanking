using IFS.DB.Application.Common.Bankware.ChartOfAccounts;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Results;
using Mapster;
using Newtonsoft.Json;

using Domain = IFS.DB.Application.Domain.Bankware.ChartOfAccounts.GetOnlineCOAByEntityTypeIdForNewApp;

namespace IFS.DB.Infrastructure.External.Bankware.ChartOfAccounts.GetOnlineCOAByEntityTypeIdForNewApp
{
    public class GetOnlineCOAByEntityTypeIdForNewAppService : BaseBankwareOpenAPIService, IGetOnlineCOAByEntityTypeIdForNewAppService
    {
        public GetOnlineCOAByEntityTypeIdForNewAppService(IParameterService parameterSvc)
           : base(parameterSvc)
        {

        }

        public async Task<ActionResult<IEnumerable<Domain.GetOnlineCOAByEntityTypeIdForNewAppResponse>>> DoActionAsync(int entityTypeId)
        {
            ActionResult<IEnumerable<Domain.GetOnlineCOAByEntityTypeIdForNewAppResponse>> result = new()
            {
                Result = Enumerable.Empty<Domain.GetOnlineCOAByEntityTypeIdForNewAppResponse>()
            };

            string apiPath = BankwareAPIURLConst.EndPoint.OnlineCOA.GetOnlineCOAByEntityTypeIdForNewApp.Replace(@"{entityTypeId}", entityTypeId.ToString());
            ActionResult<IEnumerable<GetOnlineCOAByEntityTypeIdForNewAppResponse>> responseObj = await GetAsync<IEnumerable<GetOnlineCOAByEntityTypeIdForNewAppResponse>>(apiPath);
            if (!responseObj.IsNotError)
            {
                result.Validation = responseObj.Validation;
                return result;
            }

            result.Result = responseObj.Result.Adapt<IEnumerable<Domain.GetOnlineCOAByEntityTypeIdForNewAppResponse>>();

            return result;
        }
    }
}
