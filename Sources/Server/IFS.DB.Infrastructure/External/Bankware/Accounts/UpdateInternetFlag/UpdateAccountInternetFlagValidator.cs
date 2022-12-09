using FluentValidation;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Bankware.Accounts.UpdateInternetFlag;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FvResult = FluentValidation.Results.ValidationResult;

namespace IFS.DB.Infrastructure.External.Bankware.Accounts.UpdateInternetFlag
{
    public interface IUpdateAccountInternetFlagValidator
    {
        ValidationResult Validate(UpdateAccountInternetFlagRequest account);
    }

    public class UpdateAccountInternetFlagValidator : FluentValidatorBase<UpdateAccountInternetFlagRequest>, IUpdateAccountInternetFlagValidator
    {
        public UpdateAccountInternetFlagValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(UpdateAccountInternetFlagRequest account)
        {
            FvResult result = base.Validate(account);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(account => account.AccountNumber)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
