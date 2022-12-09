using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Bankware.Accounts;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Bankware.Accounts.Create;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Accounts.CreateBWOnBoarding
{
    public interface ICreateBWOnBoardingAccountHandler : IBaseHandler
    {
        Task<ActionResult<CreateBWOnBoardingAccountResponse>> DoActionAsync(CreateBWOnBoardingAccountRequest account);
    }

    public class CreateBWOnBoardingAccountHandler : BaseHandler, ICreateBWOnBoardingAccountHandler
    {
        private readonly ICreateBWOnBoardingAccountValidator _Validator;
        private readonly IParameterService _ParameterSvc;
        private readonly ICreateAccountService _CreateAccountSvc;

        public CreateBWOnBoardingAccountHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator,
            ICreateBWOnBoardingAccountValidator validator,
            IParameterService parameterSvc,
            ICreateAccountService createAccountSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _ParameterSvc = parameterSvc;
            _CreateAccountSvc = createAccountSvc;
        }

        public async Task<ActionResult<CreateBWOnBoardingAccountResponse>> DoActionAsync(CreateBWOnBoardingAccountRequest account)
        {
            ActionResult<CreateBWOnBoardingAccountResponse> result = new ActionResult<CreateBWOnBoardingAccountResponse>()
            {
                Result = new CreateBWOnBoardingAccountResponse() { ClientNumber = account.ClientNumber }
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

            //Create BW Request Model
            CreateAccountRequest bwAccount = new CreateAccountRequest()
            {
                ClientNumber = account.ClientNumber,
                ChartOfAccount = await _ParameterSvc.GetCOAForOnBoardingAsync(),
                Currency = await _ParameterSvc.GetCurrencyForOnBoardingAsync(),
                TemplateCustomerNumber = await _ParameterSvc.GetClientTemplateForOnBoardingAsync()
            };

            //Call Bankware API to Create Account
            ActionResult<CreateAccountResponse> bwResult = await _CreateAccountSvc.DoActionAsync(bwAccount);
            if (!bwResult.IsNotError)
            {
                result.Validation = bwResult.Validation;
                return result;
            }

            result.Result.AccountNumber = bwResult.Result.AccountNumber;
            return result;
        }
    }
}
