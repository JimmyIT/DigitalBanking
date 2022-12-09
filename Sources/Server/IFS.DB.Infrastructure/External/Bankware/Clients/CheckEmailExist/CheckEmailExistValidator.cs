using FluentValidation;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Bankware.Clients.CheckEmailExist;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FvResult = FluentValidation.Results.ValidationResult;

namespace IFS.DB.Infrastructure.External.Bankware.Clients.CheckEmailExist
{
    public interface ICheckEmailExistValidator
    {
        ValidationResult Validate(CheckEmailExistRequest email);
    }

    public class CheckEmailExistValidator : FluentValidatorBase<CheckEmailExistRequest>, ICheckEmailExistValidator
    {
        public CheckEmailExistValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(CheckEmailExistRequest email)
        {
            FvResult result = base.Validate(email);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(email => email.EmailAddress)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
