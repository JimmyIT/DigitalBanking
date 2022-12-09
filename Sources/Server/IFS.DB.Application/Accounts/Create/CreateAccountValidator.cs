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

namespace IFS.DB.Application.Accounts.Create
{
    public interface ICreateAccountValidator
    {
        ValidationResult Validate(CreateAccountRequest account);
    }

    public class CreateAccountValidator : FluentValidatorBase<CreateAccountRequest>, ICreateAccountValidator
    {
        public CreateAccountValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(CreateAccountRequest account)
        {
            FvResult result = base.Validate(account);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(account => account.AccountNumber)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(account => account.ClientNumber)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
