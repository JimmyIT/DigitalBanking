using IFS.DB.Application.Common.Bankware.Accounts;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.Bankware.Accounts.UpdateInternetFlag;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IFS.DB.Infrastructure.External.Bankware.Accounts.UpdateInternetFlag
{
    public class UpdateAccountInternetFlagService : BaseBankwareOpenAPIService, IUpdateAccountInternetFlagService
    {
        private readonly IUpdateAccountInternetFlagValidator _Validator;

        public UpdateAccountInternetFlagService(IUpdateAccountInternetFlagValidator validator,
            IParameterService parameterSvc)
            : base(parameterSvc)
        {
            _Validator = validator;
        }

        public async Task<ActionResult<UpdateAccountInternetFlagResponse>> DoActionAsync(UpdateAccountInternetFlagRequest account)
        {
            ActionResult<UpdateAccountInternetFlagResponse> result = new ActionResult<UpdateAccountInternetFlagResponse>()
            {
                Result = new UpdateAccountInternetFlagResponse() { AccountNumber = account.AccountNumber }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(account);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Call Bankware API
            string apiPath = BankwareAPIURLConst.EndPoint.Account.UpdateInternetFlag.Replace("{accountNumber}", account.AccountNumber);

            ActionResult<bool> responseObj = await PUTJsonAsync<bool>(apiPath, string.Empty);
            if (!responseObj.IsNotError)
            {
                result.Validation = responseObj.Validation;
                return result;
            }

            return result;
        }
    }
}
