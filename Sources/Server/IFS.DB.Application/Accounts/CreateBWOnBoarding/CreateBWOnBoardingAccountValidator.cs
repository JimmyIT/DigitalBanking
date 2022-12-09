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

namespace IFS.DB.Application.Accounts.CreateBWOnBoarding
{
    public interface ICreateBWOnBoardingAccountValidator
    {
        ValidationResult Validate(CreateBWOnBoardingAccountRequest account);
    }

    public class CreateBWOnBoardingAccountValidator : FluentValidatorBase<CreateBWOnBoardingAccountRequest>, ICreateBWOnBoardingAccountValidator
    {
        public CreateBWOnBoardingAccountValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(CreateBWOnBoardingAccountRequest account)
        {
            FvResult result = base.Validate(account);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(account => account.ClientNumber)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
