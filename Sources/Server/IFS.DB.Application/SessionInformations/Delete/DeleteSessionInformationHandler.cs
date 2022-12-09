using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;

namespace IFS.DB.Application.SessionInformations.Delete
{
    public interface IDeleteSessionInformationHandler : IBaseHandler
    {
        Task<ActionResult<bool>> DoActionAsync(string id);
    }

    public class DeleteSessionInformationHandler : BaseHandler, IDeleteSessionInformationHandler
    {
        private readonly ISessionInformationRepo _SessionInformationRepo;

        public DeleteSessionInformationHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ISessionInformationRepo sessionInformationRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _SessionInformationRepo = sessionInformationRepo;
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

            await _SessionInformationRepo.DeleteAsync(entity);

            result.Result = true;

            return result;
        }
    }
}
