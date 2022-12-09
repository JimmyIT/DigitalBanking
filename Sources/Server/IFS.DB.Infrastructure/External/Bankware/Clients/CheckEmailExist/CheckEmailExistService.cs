using IFS.DB.Application.Common.Bankware.Clients;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.Bankware.Clients.CheckEmailExist;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IFS.DB.Infrastructure.External.Bankware.Clients.CheckEmailExist
{
    public class CheckEmailExistService : BaseBankwareOpenAPIService, ICheckEmailExistService
    {
        private readonly ICheckEmailExistValidator _Validator;

        public CheckEmailExistService(ICheckEmailExistValidator validator,
            IParameterService parameterSvc) 
            : base(parameterSvc)
        {
            _Validator = validator;
        }

        public async Task<ActionResult<CheckEmailExistResponse>> DoActionAsync(CheckEmailExistRequest email)
        {
            ActionResult<CheckEmailExistResponse> result = new ActionResult<CheckEmailExistResponse>()
            {
                Result = new CheckEmailExistResponse()
                {
                    EmailAddress = email.EmailAddress,
                    IsExist = false
                }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(email);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Call Bankware API
            string apiPath = BankwareAPIURLConst.EndPoint.Customer.CheckEmailExist.Replace("{email}", email.EmailAddress);
            ActionResult<bool> responseObj = await GetAsync<bool>(apiPath);
            if (!responseObj.IsNotError)
            {
                result.Validation = responseObj.Validation;
                return result;
            }

            result.Result.IsExist = responseObj.Result;
            return result;
        }
    }
}
