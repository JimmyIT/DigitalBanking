using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Common;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;

namespace IFS.DB.Application.SessionInformations.Reset
{
    public interface IResetSessionInformationHandler : IBaseHandler
    {
        Task<ActionResult<bool>> DoActionAsync(string id);
    }

    public class ResetSessionInformationHandler : BaseHandler, IResetSessionInformationHandler
    {
        private readonly ISessionInformationRepo _SessionInformationRepo;
        private readonly ISiteParameterService _SiteParameterSvc;
        private readonly IDateTimeProvider _DateTimeProvider;

        public ResetSessionInformationHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ISessionInformationRepo sessionInformationRepo,
            ISiteParameterService siteParameterSvc,
            IDateTimeProvider dateTimeProvider)
            : base(errorMessageSvc, headerValidator)
        {
            _SessionInformationRepo = sessionInformationRepo;
            _SiteParameterSvc = siteParameterSvc;
            _DateTimeProvider = dateTimeProvider;
        }

        public async Task<ActionResult<bool>> DoActionAsync(string id)
        {
            ActionResult<bool> result = new ActionResult<bool>()
            {
                Result = false
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Get Session Info
            SessionInformation entity = await _SessionInformationRepo.GetByIdAsync(id);
            if (entity == null)
            {
                result.IsNotFound = true;
                return result;
            }

            //Reset Session Info
            entity.Expiry = _DateTimeProvider.Now().AddMinutes(await _SiteParameterSvc.GetExternalCustomerTimeOutAsync());
            entity.LogonId = string.Empty;
            entity.UserId = string.Empty;
            entity.ClientNumber = string.Empty;
            entity.ClientInView = string.Empty;
            entity.InternalId = string.Empty;
            entity.LogonAttempt = 0;

            await _SessionInformationRepo.UpdateAsync(entity);

            result.Result = true;

            return result;
        }
    }
}
