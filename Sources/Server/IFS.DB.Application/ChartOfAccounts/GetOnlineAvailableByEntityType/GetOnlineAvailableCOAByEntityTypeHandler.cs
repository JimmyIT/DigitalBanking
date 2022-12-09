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

using BWDomain = IFS.DB.Application.Domain.Bankware.ChartOfAccounts.GetOnlineAvailableByEntityType;

namespace IFS.DB.Application.ChartOfAccounts.GetOnlineAvailableByEntityType
{
    public interface IGetOnlineAvailableCOAByEntityTypeHandler : IBaseHandler
    {
        public Task<ActionResult<IEnumerable<GetOnlineAvailableCOAByEntityTypeResponse>>> DoActionAsync(int entityTypeId);
    }

    public class GetOnlineAvailableCOAByEntityTypeHandler : BaseHandler, IGetOnlineAvailableCOAByEntityTypeHandler
    {
        private readonly IGetOnlineAvailableCOAByEntityTypeService _GetOnlineAvailableCOAByEntityTypeSvc;

        public GetOnlineAvailableCOAByEntityTypeHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IGetOnlineAvailableCOAByEntityTypeService getOnlineAvailableCOAByEntityTypeSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _GetOnlineAvailableCOAByEntityTypeSvc = getOnlineAvailableCOAByEntityTypeSvc;
        }

        public async Task<ActionResult<IEnumerable<GetOnlineAvailableCOAByEntityTypeResponse>>> DoActionAsync(int entityTypeId)
        {
            ActionResult<IEnumerable<GetOnlineAvailableCOAByEntityTypeResponse>> result = new()
            {
                Result = Enumerable.Empty<GetOnlineAvailableCOAByEntityTypeResponse>()
            };

            ActionResult<IEnumerable<BWDomain.GetOnlineAvailableCOAByEntityTypeResponse>> responseResult = await _GetOnlineAvailableCOAByEntityTypeSvc.DoActionAsync(entityTypeId);
            if (responseResult != null)
            {
                result.Result = responseResult.Result.Adapt<IEnumerable<GetOnlineAvailableCOAByEntityTypeResponse>>();
            }
            return result;
        }
    }
}
