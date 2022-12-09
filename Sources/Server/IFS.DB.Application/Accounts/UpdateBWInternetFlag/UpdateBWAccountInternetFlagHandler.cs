using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Bankware.Accounts;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Bankware.Accounts.UpdateInternetFlag;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Accounts.UpdateBWInternetFlag
{
    public interface IUpdateBWAccountInternetFlagHandler : IBaseHandler
    {
        Task<ActionResult<UpdateBWAccountInternetFlagResponse>> DoActionAsync(UpdateBWAccountInternetFlagRequest account);
    }

    public class UpdateBWAccountInternetFlagHandler : BaseHandler, IUpdateBWAccountInternetFlagHandler
    {
        private readonly IUpdateBWAccountInternetFlagValidator _Validator;
        private readonly IUpdateAccountInternetFlagService _UpdateAccountInternetFlagSvc;

        public UpdateBWAccountInternetFlagHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IUpdateBWAccountInternetFlagValidator validator,
            IUpdateAccountInternetFlagService updateAccountInternetFlagSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _UpdateAccountInternetFlagSvc = updateAccountInternetFlagSvc;
        }

        public async Task<ActionResult<UpdateBWAccountInternetFlagResponse>> DoActionAsync(UpdateBWAccountInternetFlagRequest account)
        {
            ActionResult<UpdateBWAccountInternetFlagResponse> result = new ActionResult<UpdateBWAccountInternetFlagResponse>()
            {
                Result = new UpdateBWAccountInternetFlagResponse() { AccountNumber = account.AccountNumber }
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
            UpdateAccountInternetFlagRequest bwAccount = new UpdateAccountInternetFlagRequest()
            {
                AccountNumber = account.AccountNumber
            };

            //Call Bankware API to Create Account
            ActionResult<UpdateAccountInternetFlagResponse> bwResult = await _UpdateAccountInternetFlagSvc.DoActionAsync(bwAccount);
            if (!bwResult.IsNotError)
            {
                result.Validation = bwResult.Validation;
                return result;
            }

            return result;
        }
    }
}
