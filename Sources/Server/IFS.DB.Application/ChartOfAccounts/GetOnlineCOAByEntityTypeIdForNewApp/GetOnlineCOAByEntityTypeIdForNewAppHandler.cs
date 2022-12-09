using IFS.DB.Application.ChartOfAccounts.GetOnlineCOAByEntityTypeIdForNewApp;
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

using BWDomain = IFS.DB.Application.Domain.Bankware.ChartOfAccounts.GetOnlineCOAByEntityTypeIdForNewApp;

namespace IFS.DB.Application.ChartOfAccounts.GetOnlineCOAByEntityTypeIdForNewApp
{
    public interface IGetOnlineCOAByEntityTypeIdForNewAppHandler : IBaseHandler
    {
        public Task<ActionResult<IEnumerable<GetOnlineCOAByEntityTypeIdForNewAppResponse>>> DoActionAsync(int entityTypeId);
    }

    public class GetOnlineCOAByEntityTypeIdForNewAppHandler : BaseHandler, IGetOnlineCOAByEntityTypeIdForNewAppHandler
    {
        private readonly IGetOnlineCOAByEntityTypeIdForNewAppService _GetOnlAvailByEntityTypeAndAvailNewAppSvc;
        public GetOnlineCOAByEntityTypeIdForNewAppHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IGetOnlineCOAByEntityTypeIdForNewAppService getOnlAvailByEntityTypeAndAvailNewAppSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _GetOnlAvailByEntityTypeAndAvailNewAppSvc = getOnlAvailByEntityTypeAndAvailNewAppSvc;
        }

        public async Task<ActionResult<IEnumerable<GetOnlineCOAByEntityTypeIdForNewAppResponse>>> DoActionAsync(int entityTypeId)
        {
            ActionResult<IEnumerable<GetOnlineCOAByEntityTypeIdForNewAppResponse>> result = new()
            {
                Result = Enumerable.Empty<GetOnlineCOAByEntityTypeIdForNewAppResponse>()
            };

            ActionResult<IEnumerable<BWDomain.GetOnlineCOAByEntityTypeIdForNewAppResponse>> responseResult = await _GetOnlAvailByEntityTypeAndAvailNewAppSvc.DoActionAsync(entityTypeId);
            if (responseResult != null)
            {
                result.Result = responseResult.Result.Adapt<IEnumerable<GetOnlineCOAByEntityTypeIdForNewAppResponse>>();
            }
            return result;
        }
    }
}
