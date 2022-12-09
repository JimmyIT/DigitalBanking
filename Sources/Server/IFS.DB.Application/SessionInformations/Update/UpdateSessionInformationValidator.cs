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

namespace IFS.DB.Application.SessionInformations.Update
{
    public interface IUpdateSessionInformationValidator
    {
        ValidationResult Validate(UpdateSessionInformationRequest sessionInfo);
    }

    public class UpdateSessionInformationValidator : FluentValidatorBase<UpdateSessionInformationRequest>, IUpdateSessionInformationValidator
    {
        public UpdateSessionInformationValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(UpdateSessionInformationRequest sessionInfo)
        {
            FvResult result = base.Validate(sessionInfo);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            //Internal Id
            RuleFor(sessionInfo => sessionInfo.InternalId)
                .MaximumLength(50).WithCustomError(new MaxLengthError());

            //Logon Id
            RuleFor(sessionInfo => sessionInfo.LogonId)
                .MaximumLength(50).WithCustomError(new MaxLengthError());

            //User Id
            RuleFor(sessionInfo => sessionInfo.UserId)
                .MaximumLength(50).WithCustomError(new MaxLengthError());

            //Client Number
            RuleFor(sessionInfo => sessionInfo.ClientNumber)
                .MaximumLength(50).WithCustomError(new MaxLengthError());

            //Account Number
            RuleFor(sessionInfo => sessionInfo.AccountNumber)
                .MaximumLength(50).WithCustomError(new MaxLengthError());

            //Client In View
            RuleFor(sessionInfo => sessionInfo.ClientInView)
                .MaximumLength(50).WithCustomError(new MaxLengthError());

            //Beneficiary Reference
            RuleFor(sessionInfo => sessionInfo.BeneficiaryReference)
                .MaximumLength(35).WithCustomError(new MaxLengthError());

            //Transfer Reference
            RuleFor(sessionInfo => sessionInfo.TransferReference)
                .MaximumLength(16).WithCustomError(new MaxLengthError());

            //Payment Reference
            RuleFor(sessionInfo => sessionInfo.PaymentReference)
                .MaximumLength(16).WithCustomError(new MaxLengthError());

            //Users Internal Id
            RuleFor(sessionInfo => sessionInfo.UsersInternalID)
                .MaximumLength(50).WithCustomError(new MaxLengthError());

            //Users Culture
            RuleFor(sessionInfo => sessionInfo.UsersCulture)
                .MaximumLength(10).WithCustomError(new MaxLengthError());

            //Card Number
            RuleFor(sessionInfo => sessionInfo.CardNumber)
                .MaximumLength(50).WithCustomError(new MaxLengthError());

            //Payment Card Last 4 Digits
            RuleFor(sessionInfo => sessionInfo.PaymentCardLast4Digits)
                .MaximumLength(4).WithCustomError(new MaxLengthError());

            //Hosted Data Id
            RuleFor(sessionInfo => sessionInfo.HostedDataID)
                .MaximumLength(50).WithCustomError(new MaxLengthError());
        }
    }
}
