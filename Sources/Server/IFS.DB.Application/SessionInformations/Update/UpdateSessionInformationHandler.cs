using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Common;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;

namespace IFS.DB.Application.SessionInformations.Update
{
    public interface IUpdateSessionInformationHandler : IBaseHandler
    {
        Task<ActionResult<bool>> DoActionAsync(string id, UpdateSessionInformationRequest sessionInfo);
    }

    public class UpdateSessionInformationHandler : BaseHandler, IUpdateSessionInformationHandler
    {
        private readonly IUpdateSessionInformationValidator _Validator;
        private readonly ISessionInformationRepo _SessionInformationRepo;

        public UpdateSessionInformationHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IUpdateSessionInformationValidator validator,
            ISessionInformationRepo sessionInformationRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _SessionInformationRepo = sessionInformationRepo;
        }

        public async Task<ActionResult<bool>> DoActionAsync(string id, UpdateSessionInformationRequest sessionInfo)
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

            //Validate Content
            valResult = _Validator.Validate(sessionInfo);
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

            sessionInfo.Adapt(entity);

            await _SessionInformationRepo.UpdateAsync(entity);

            result.Result = true;

            return result;
        }
    }
}
