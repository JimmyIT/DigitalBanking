using IFS.DB.Application.Common.Bankware.ChartOfAccounts;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Results;
using Mapster;

using Domain = IFS.DB.Application.Domain.Bankware.ChartOfAccounts.GetOnlineAvailableByEntityType;

namespace IFS.DB.Infrastructure.External.Bankware.ChartOfAccounts.GetOnlineAvailableByEntityType
{
    public class GetOnlineAvailableCOAByEntityTypeService : BaseBankwareOpenAPIService, IGetOnlineAvailableCOAByEntityTypeService
    {
        public GetOnlineAvailableCOAByEntityTypeService(IParameterService parameterSvc)
           : base(parameterSvc)
        {

        }

        public async Task<ActionResult<IEnumerable<Domain.GetOnlineAvailableCOAByEntityTypeResponse>>> DoActionAsync(int entityTypeId)
        {
            ActionResult<IEnumerable<Domain.GetOnlineAvailableCOAByEntityTypeResponse>> result = new()
            {
                Result = Enumerable.Empty<Domain.GetOnlineAvailableCOAByEntityTypeResponse>()
            };

            // Call Bankware API
            string apiPath = BankwareAPIURLConst.EndPoint.OnlineCOA.GetOnlineCOAsByEntityTypeId.Replace(@"{entityType}", entityTypeId.ToString());
            ActionResult<IEnumerable<GetOnlineAvailableCOAByEntityTypeResponse>> responseObj = await GetAsync<IEnumerable<GetOnlineAvailableCOAByEntityTypeResponse>>(apiPath);
            if (!responseObj.IsNotError)
            {
                result.Validation = responseObj.Validation;
                return result;
            }

            result.Result = responseObj.Result.Adapt<IEnumerable<Domain.GetOnlineAvailableCOAByEntityTypeResponse>>();

            return result;
        }
    }
}
