using FluentValidation;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FvResult = FluentValidation.Results.ValidationResult;

namespace IFS.DB.Application.OpenAPI.Token
{
    public interface ITokenValidator
    {
        ValidationResult Validate(TokenRequest request);
    }

    public class TokenValidator : FluentValidatorBase<TokenRequest>, ITokenValidator
    {
        public TokenValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(TokenRequest request)
        {
            FvResult result = base.Validate(request);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(request => request.Username)
                .NotEmpty().WithCustomError(new RequireError());

            RuleFor(request => request.Password)
                .NotEmpty().WithCustomError(new RequireError());
        }
    }
}
