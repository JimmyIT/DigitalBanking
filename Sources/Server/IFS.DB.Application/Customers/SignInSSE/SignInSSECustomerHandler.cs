using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.EF;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.API;
using IFS.DB.Application.Domain.ErrorCodes;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IFS.DB.Application.Common.Interfaces.Data;
using Microsoft.Extensions.Options;

namespace IFS.DB.Application.Customers.SignInSSE
{
    public interface ISignInSSECustomerHandler : IBaseHandler
    {
        Task<ActionResult<SignInSSECustomerResponse>> DoActionAsync(SignInSSECustomerRequest customer);
    }

    public class SignInSSECustomerHandler : BaseHandler, ISignInSSECustomerHandler
    {
        private readonly ISignInSSECustomerValidator _Validator;
        private readonly IParameterService _ParameterSvc;
        private readonly IStringProvider _StringProvider;
        private readonly IDateTimeProvider _DateProvider;

        private readonly JwtConfig _JwtConfig;

        public SignInSSECustomerHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator,
            ISignInSSECustomerValidator validator,
            IParameterService parameterSvc,
            IStringProvider stringProvider,
            IDateTimeProvider dateProvider,
            IOptions<JwtConfig> options)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _ParameterSvc = parameterSvc;
            _StringProvider = stringProvider;
            _DateProvider = dateProvider;

            _JwtConfig = options.Value;
        }

        public async Task<ActionResult<SignInSSECustomerResponse>> DoActionAsync(SignInSSECustomerRequest customer)
        {
            ActionResult<SignInSSECustomerResponse> result = new ActionResult<SignInSSECustomerResponse>()
            {
                Result = new SignInSSECustomerResponse() { AuthType = TwoFactorAuthTypeEnum.None }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(customer);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Set temp data
            result.Result.AuthType = TwoFactorAuthTypeEnum.Email;



            return result;
        }
    }
}
