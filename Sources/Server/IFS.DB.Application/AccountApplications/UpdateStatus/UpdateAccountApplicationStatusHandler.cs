using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.UpdateStatus
{
    public interface IUpdateAccountApplicationStatusHandler : IBaseHandler
    {
        Task<ActionResult<UpdateAccountApplicationStatusResponse>> DoActionAsync(UpdateAccountApplicationStatusRequest accApp);
    }

    public class UpdateAccountApplicationStatusHandler : BaseHandler, IUpdateAccountApplicationStatusHandler
    {
        private readonly IUpdateAccountApplicationStatusValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public UpdateAccountApplicationStatusHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IUpdateAccountApplicationStatusValidator validator,
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public async Task<ActionResult<UpdateAccountApplicationStatusResponse>> DoActionAsync(UpdateAccountApplicationStatusRequest accApp)
        {
            ActionResult<UpdateAccountApplicationStatusResponse> result = new ActionResult<UpdateAccountApplicationStatusResponse>()
            {
                Result = new UpdateAccountApplicationStatusResponse() { ApplicationId = accApp.ApplicationId }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(accApp);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Get Detail Id
            AccountApplication entity = await _AccountApplicationRepo.GetByIdAsync(accApp.ApplicationId);

            //Map Model to Entity
            entity.Status = (int)accApp.Status;
            entity.ErrorDescription = accApp.ErrorDescription;

            if (!string.IsNullOrEmpty(accApp.ClientNumber))
                entity.AllocatedClientId = accApp.ClientNumber;

            if (!string.IsNullOrEmpty(accApp.AccountNumber))
                entity.AllocatedAccountId1 = accApp.AccountNumber;

            if (!string.IsNullOrEmpty(accApp.AMLtracRefId))
                entity.AmltracRefId = accApp.AMLtracRefId;

            await _AccountApplicationRepo.UpdateAsync(entity);

            return result;
        }
    }
}
