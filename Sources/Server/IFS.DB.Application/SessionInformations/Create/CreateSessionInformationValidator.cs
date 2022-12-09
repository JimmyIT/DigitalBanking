using FluentValidation;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FvResult = FluentValidation.Results.ValidationResult;

namespace IFS.DB.Application.SessionInformations.Create
{
    public interface ICreateSessionInformationValidator
    {
        ValidationResult Validate(CreateSessionInformationRequest sessionInfo);
    }

    public class CreateSessionInformationValidator : FluentValidatorBase<CreateSessionInformationRequest>, ICreateSessionInformationValidator
    {
        public CreateSessionInformationValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(CreateSessionInformationRequest sessionInfo)
        {
            FvResult result = base.Validate(sessionInfo);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(sessionInfo => sessionInfo.SessionId)
                .NotEmpty().WithCustomError(_ErrorMessageSvc.CreateAsync(ErrorMessageCode.SessionIdRequired).GetAwaiter().GetResult())
                .MaximumLength(50).WithCustomError(_ErrorMessageSvc.CreateAsync(ErrorMessageCode.SessionIdRequired).GetAwaiter().GetResult());
        }
    }
}
