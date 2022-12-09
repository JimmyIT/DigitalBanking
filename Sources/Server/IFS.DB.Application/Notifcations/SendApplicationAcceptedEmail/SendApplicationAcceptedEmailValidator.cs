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

namespace IFS.DB.Application.Notifcations.SendApplicationAcceptedEmail
{
    public interface ISendApplicationAcceptedEmailValidator
    {
        ValidationResult Validate(SendApplicationAcceptedEmailRequest email);
    }

    public class SendApplicationAcceptedEmailValidator : FluentValidatorBase<SendApplicationAcceptedEmailRequest>, ISendApplicationAcceptedEmailValidator
    {
        public SendApplicationAcceptedEmailValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(SendApplicationAcceptedEmailRequest email)
        {
            FvResult result = base.Validate(email);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(email => email.Email)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
