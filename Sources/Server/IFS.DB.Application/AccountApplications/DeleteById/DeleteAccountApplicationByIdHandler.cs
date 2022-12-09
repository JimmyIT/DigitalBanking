using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.DeleteById
{
    public interface IDeleteAccountApplicationByIdHandler : IBaseHandler
    {
        Task<ActionResult<bool>> DoActionAsync(Guid id);
    }

    public class DeleteAccountApplicationByIdHandler : BaseHandler, IDeleteAccountApplicationByIdHandler
    {
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public DeleteAccountApplicationByIdHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator,
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public async Task<ActionResult<bool>> DoActionAsync(Guid id)
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

            await _AccountApplicationRepo.DeleteAsync(id);
            result.Result = true;

            return result;
        }
    }
}
