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

namespace IFS.DB.Application.Notifcations.SendApplicationAcceptedSMS
{
    public interface ISendApplicationAcceptedSMSValidator
    {
        ValidationResult Validate(SendApplicationAcceptedSMSRequest sms);
    }

    public class SendApplicationAcceptedSMSValidator : FluentValidatorBase<SendApplicationAcceptedSMSRequest>, ISendApplicationAcceptedSMSValidator
    {
        public SendApplicationAcceptedSMSValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(SendApplicationAcceptedSMSRequest sms)
        {
            FvResult result = base.Validate(sms);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(sms => sms.PhoneNumber)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
