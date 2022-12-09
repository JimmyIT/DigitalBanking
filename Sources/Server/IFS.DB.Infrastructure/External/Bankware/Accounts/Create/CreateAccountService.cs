using IFS.DB.Application.Common.Bankware.Accounts;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

using Domain = IFS.DB.Application.Domain.Bankware.Accounts.Create;

namespace IFS.DB.Infrastructure.External.Bankware.Accounts.Create
{
    public class CreateAccountService : BaseBankwareOpenAPIService, ICreateAccountService
    {
        private readonly ICreateAccountValidator _Validator;

        public CreateAccountService(ICreateAccountValidator validator,
            IParameterService parameterSvc)
            : base(parameterSvc)
        {
            _Validator = validator;
        }

        public async Task<ActionResult<Domain.CreateAccountResponse>> DoActionAsync(Domain.CreateAccountRequest account)
        {
            ActionResult<Domain.CreateAccountResponse> result = new ActionResult<Domain.CreateAccountResponse>()
            {
                Result = new Domain.CreateAccountResponse() { AccountNumber = string.Empty }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(account);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Create model to call Bankware API
            CreateAccountRequest accountBW = new CreateAccountRequest
            {
                AltClientNumber = string.Empty,
                AccountNumber = string.Empty,
                AltAccountNumber = string.Empty,
                Sequence = string.Empty,
                ChartOfAccount = account.ChartOfAccount,
                ClientNumber = account.ClientNumber,
                Currency = account.Currency,
                TemplateCustomerNumber = account.TemplateCustomerNumber,
                InternetAccessRequired = "N",
                CurrentBalance = 0,
                ClearedBalance = 0
            };

            //Call Bankware API
            string apiPath = BankwareAPIURLConst.EndPoint.Account.Create;

            ActionResult<CreateAccountResponse> responseObj = await POSTJsonAsync<CreateAccountResponse>(apiPath, JsonConvert.SerializeObject(accountBW));
            if (!responseObj.IsNotError)
            {
                result.Validation = responseObj.Validation;
                return result;
            }

            result.Result.AccountNumber = responseObj.Result.AccountNumber;

            return result;
        }

    }
}
