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

namespace IFS.DB.Application.Notifcations.SendSMS
{
    public interface ISendSMSValidator
    {
        ValidationResult Validate(SendSMSRequest sms);
    }

    public class SendSMSValidator : FluentValidatorBase<SendSMSRequest>, ISendSMSValidator
    {
        public SendSMSValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(SendSMSRequest sms)
        {
            FvResult result = base.Validate(sms);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(sms => sms.PhoneNumber)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(sms => sms.Message)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
