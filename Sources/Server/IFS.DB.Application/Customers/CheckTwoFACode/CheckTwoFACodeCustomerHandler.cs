using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common;
using IFS.DB.Application.Domain.API;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Domain.ErrorCodes;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IFS.DB.Application.Customers.CheckTwoFACode
{
    public interface ICheckTwoFACodeCustomerHandler : IBaseHandler
    {
        Task<ActionResult<CheckTwoFACodeCustomerResponse>> DoActionAsync(CheckTwoFACodeCustomerRequest customer);
    }

    public class CheckTwoFACodeCustomerHandler : BaseHandler, ICheckTwoFACodeCustomerHandler
    {
        private readonly ICheckTwoFACodeCustomerValidator _Validator;
        private readonly IParameterService _ParameterSvc;
        private readonly IStringProvider _StringProvider;
        private readonly IDateTimeProvider _DateProvider;

        private readonly JwtConfig _JwtConfig;

        public CheckTwoFACodeCustomerHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator,
            ICheckTwoFACodeCustomerValidator validator,
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

        public async Task<ActionResult<CheckTwoFACodeCustomerResponse>> DoActionAsync(CheckTwoFACodeCustomerRequest customer)
        {
            ActionResult<CheckTwoFACodeCustomerResponse> result = new ActionResult<CheckTwoFACodeCustomerResponse>()
            {
                Result = new CheckTwoFACodeCustomerResponse() { AccessToken = string.Empty }
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
            //Check Tolken Life Cirle
            int tokenLifeCirle = await _ParameterSvc.GetTokenLifeCirleAsync();
            if (tokenLifeCirle <= 0)
            {
                IList<Error> errors = new List<Error>();
                errors.Add(new MissingSettingError("Token Life Cirle"));
                result.Validation = new ValidationResult(errors);
                return result;
            }

            //create claims details based on the user information
            var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub, _JwtConfig.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, _StringProvider.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, _DateProvider.UtcNow().ToString()),
                        new Claim("InternalId", customer.InternalId)
                        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JwtConfig.Key));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_JwtConfig.Issuer, _JwtConfig.Audience, claims, expires: _DateProvider.UtcNow().AddHours(tokenLifeCirle), signingCredentials: signIn);

            result.Result = new CheckTwoFACodeCustomerResponse()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                TokenType = "bearer",
                ExpriesIn = tokenLifeCirle * 60 * 60
            };



            return result;
        }
    }
}
