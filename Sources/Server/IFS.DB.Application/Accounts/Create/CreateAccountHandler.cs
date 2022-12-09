using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Bankware.Accounts;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Bankware.Accounts.GetByAccountNumber;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Accounts.Create
{
    public interface ICreateAccountHandler : IBaseHandler
    {
        Task<ActionResult<CreateAccountResponse>> DoActionAsync(CreateAccountRequest account);
    }

    public class CreateAccountHandler : BaseHandler, ICreateAccountHandler
    {
        private readonly ICreateAccountValidator _Validator;
        private readonly IDateTimeProvider _DateTimeProvider;
        private readonly IGetAccountByAccountNumberService _GetAccountByAccountNumberSvc;
        private readonly IAccountRepo _AccountRepo;
        private readonly IImportParameterRepo _ImportParameterRepo;

        public CreateAccountHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ICreateAccountValidator validator,
            IDateTimeProvider dateTimeProvider,
            IGetAccountByAccountNumberService getAccountByAccountNumberSvc,
            IAccountRepo accountRepo,
            IImportParameterRepo importParameterRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _DateTimeProvider = dateTimeProvider;
            _GetAccountByAccountNumberSvc = getAccountByAccountNumberSvc;
            _AccountRepo = accountRepo;
            _ImportParameterRepo = importParameterRepo;
        }

        public async Task<ActionResult<CreateAccountResponse>> DoActionAsync(CreateAccountRequest account)
        {
            ActionResult<CreateAccountResponse> result = new ActionResult<CreateAccountResponse>()
            {
                Result = new CreateAccountResponse() 
                { 
                    ClientNumber = account.ClientNumber,
                    AccountNumber = account.AccountNumber
                }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(account);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Call Bankware API to get Account Detail
            ActionResult<GetByAccountNumberResponse> bwResult = await _GetAccountByAccountNumberSvc.DoActionAsync(account.AccountNumber);
            if (!bwResult.IsNotError)
            {
                result.Validation = bwResult.Validation;
                return result;
            }

            GetByAccountNumberResponse bwAccount = bwResult.Result;

            //Mapping Entity
            bool isNegativeAmountsRepresent = await _ImportParameterRepo.CheckNegativeAmountsRepresentAsync();

            Account accountEntity = bwResult.Result.Adapt<Account>();
            accountEntity.AvailableBalance = isNegativeAmountsRepresent ? -bwAccount.ClearedBalance.GetValueOrDefault(0) : bwAccount.ClearedBalance.GetValueOrDefault(0);
            accountEntity.CurrentBalance = isNegativeAmountsRepresent ? -bwAccount.CurrentBalance.GetValueOrDefault(0) : bwAccount.CurrentBalance.GetValueOrDefault(0);
            accountEntity.OverdraftReview = _DateTimeProvider.Now();
            accountEntity.PermittedActions = string.Empty;
            accountEntity.VoucherId = string.Empty;

            await _AccountRepo.InsertAsync(accountEntity);
            return result;
        }
    }
}
