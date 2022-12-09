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

namespace IFS.DB.Application.Notifcations.SendMail
{
    public interface ISendMailValidator
    {
        ValidationResult Validate(SendMailRequest email);
    }

    public class SendMailValidator : FluentValidatorBase<SendMailRequest>, ISendMailValidator
    {
        public SendMailValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(SendMailRequest email)
        {
            FvResult result = base.Validate(email);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(email => email.Subject)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(email => email.Recipients)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(email => email.Message)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
