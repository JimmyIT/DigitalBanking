using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Accounts.DeleteByAccountNumber
{
    public interface IDeleteAccountByAccountNumberHandler : IBaseHandler
    {
        Task<ActionResult<bool>> DoActionAsync(string accountNumber);
    }

    public class DeleteAccountByAccountNumberHandler : BaseHandler, IDeleteAccountByAccountNumberHandler
    {
        private readonly IAccountRepo _AccountRepo;

        public DeleteAccountByAccountNumberHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IAccountRepo accountRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _AccountRepo = accountRepo;
        }

        public async Task<ActionResult<bool>> DoActionAsync(string accountNumber)
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

            await _AccountRepo.DeleteByAccountNumberAsync(accountNumber);
            result.Result = true;

            return result;
        }
    }
}
