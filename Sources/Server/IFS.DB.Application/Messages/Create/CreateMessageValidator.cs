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

namespace IFS.DB.Application.Messages.Create
{
    public interface ICreateMessageValidator
    {
        ValidationResult Validate(CreateMessageRequest message);
    }

    public class CreateMessageValidator : FluentValidatorBase<CreateMessageRequest>, ICreateMessageValidator
    {
        public CreateMessageValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(CreateMessageRequest message)
        {
            FvResult result = base.Validate(message);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(message => message.Direction)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(message => message.MessageType)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(message => message.MessageContent)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
