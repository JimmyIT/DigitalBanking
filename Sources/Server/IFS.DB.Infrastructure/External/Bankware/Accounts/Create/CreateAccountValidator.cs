using FluentValidation;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FvResult = FluentValidation.Results.ValidationResult;
using Domain = IFS.DB.Application.Domain.Bankware.Accounts.Create;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;

namespace IFS.DB.Infrastructure.External.Bankware.Accounts.Create
{
    public interface ICreateAccountValidator
    {
        ValidationResult Validate(Domain.CreateAccountRequest account);
    }

    public class CreateAccountValidator : FluentValidatorBase<Domain.CreateAccountRequest>, ICreateAccountValidator
    {
        public CreateAccountValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(Domain.CreateAccountRequest account)
        {
            FvResult result = base.Validate(account);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(account => account.ChartOfAccount)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(account => account.ClientNumber)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(account => account.Currency)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(account => account.TemplateCustomerNumber)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
