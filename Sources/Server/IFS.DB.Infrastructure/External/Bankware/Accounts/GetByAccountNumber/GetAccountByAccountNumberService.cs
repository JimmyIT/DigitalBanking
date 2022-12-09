using IFS.DB.Application.Common.Bankware.Accounts;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

using Domain = IFS.DB.Application.Domain.Bankware.Accounts.GetByAccountNumber;

namespace IFS.DB.Infrastructure.External.Bankware.Accounts.GetByAccountNumber
{
    public class GetAccountByAccountNumberService : BaseBankwareOpenAPIService, IGetAccountByAccountNumberService
    {
        private readonly IAccountGetByAccountNumberValidator _Validator;

        public GetAccountByAccountNumberService(IAccountGetByAccountNumberValidator validator,
            IParameterService parameterSvc)
            : base(parameterSvc)
        {
            _Validator = validator;
        }

        public async Task<ActionResult<Domain.GetByAccountNumberResponse>> DoActionAsync(string accountNumber)
        {
            ActionResult<Domain.GetByAccountNumberResponse> result = new ActionResult<Domain.GetByAccountNumberResponse>()
            {
                Result = null
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(accountNumber);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            // Call Bankware API
            string apiPath = BankwareAPIURLConst.EndPoint.Account.GetByAccountNumber.Replace("{accountNumber}", accountNumber);
            ActionResult<GetByAccountNumberResponse> responseObj = await GetAsync<GetByAccountNumberResponse>(apiPath);
            if (!responseObj.IsNotError)
            {
                result.Validation = responseObj.Validation;
                return result;
            }

            GetByAccountNumberResponse.ConfigMapping();

            result.Result = responseObj.Result.Adapt<Domain.GetByAccountNumberResponse>();

            return result;
        }
    }
}
