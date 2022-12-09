using IFS.Common;
using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.API;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.OpenAPI.Token
{
    public interface ITokenHandler : IBaseHandler
    {
        Task<ActionResult<TokenResponse>> DoActionAsync(TokenRequest request);
    }

    public class TokenHandler : BaseHandler, ITokenHandler
    {
        private readonly ITokenValidator _Validator;
        private readonly IOpenAPIRepo _OpenAPIRepo;
        private readonly IParameterService _ParameterSvc;
        private readonly IStringProvider _StringProvider;
        private readonly IDateTimeProvider _DateProvider;

        private readonly JwtConfig _JwtConfig;

        public TokenHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            ITokenValidator validator,
            IOpenAPIRepo openAPIRepo,
            IParameterService parameterSvc,
            IStringProvider stringProvider,
            IDateTimeProvider dateProvider,
            IOptions<JwtConfig> options)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _OpenAPIRepo = openAPIRepo;
            _ParameterSvc = parameterSvc;
            _StringProvider = stringProvider;
            _DateProvider = dateProvider;

            _JwtConfig = options.Value;
        }

        public async Task<ActionResult<TokenResponse>> DoActionAsync(TokenRequest request)
        {
            ActionResult<TokenResponse> result = new ActionResult<TokenResponse>()
            {
                Result = new TokenResponse() { Access_token = string.Empty }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(request);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Get User
            OpenApiUser userEntity = await _OpenAPIRepo.GetUserByUsernameAsync(request.Username);

            //User doesn't exist
            if (userEntity == null)
            {
                IList<Error> errors = new List<Error>();
                errors.Add(new CustomError("Invalid credentials"));
                result.Validation = new ValidationResult(errors);
                return result;
            }

            //Check Password
            if (userEntity.Password != Cryptor.Encrypt(request.Password))
            {
                IList<Error> errors = new List<Error>();
                errors.Add(new CustomError("Invalid credentials"));
                result.Validation = new ValidationResult(errors);
                return result;
            }

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
                        new Claim("User", request.Username)
                        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JwtConfig.Key));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_JwtConfig.Issuer, _JwtConfig.Audience, claims, expires: _DateProvider.UtcNow().AddHours(tokenLifeCirle), signingCredentials: signIn);

            result.Result = new TokenResponse()
            {
                Access_token = new JwtSecurityTokenHandler().WriteToken(token),
                Token_type = "bearer",
                Expries_in = tokenLifeCirle * 60 * 60
            };

            return result;
        }
    }
}
