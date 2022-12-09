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

namespace IFS.DB.Application.Messages.UpdateStatus
{
    public interface IUpdateMessageStatusValidator
    {
        ValidationResult Validate(UpdateMessageStatusRequest message);
    }

    public class UpdateMessageStatusValidator : FluentValidatorBase<UpdateMessageStatusRequest>, IUpdateMessageStatusValidator
    {
        public UpdateMessageStatusValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(UpdateMessageStatusRequest message)
        {
            FvResult result = base.Validate(message);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(message => message.MessageId)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(message => message.Status)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
