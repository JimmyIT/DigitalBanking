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

namespace IFS.DB.Application.AccountApplications.NotifyKYCApprove
{
    public interface INotifyKYCApproveValidator
    {
        ValidationResult Validate(NotifyKYCApproveRequest kyc);
    }

    public class NotifyKYCApproveValidator : FluentValidatorBase<NotifyKYCApproveRequest>, INotifyKYCApproveValidator
    {
        public NotifyKYCApproveValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        {
        }

        public new ValidationResult Validate(NotifyKYCApproveRequest kyc)
        {
            FvResult result = base.Validate(kyc);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(kyc => kyc.LinkId)
                .NotEmpty().WithCustomError(new RequireError());

            RuleFor(kyc => kyc.RequestId)
                .NotEmpty().WithCustomError(new RequireError());

            RuleFor(kyc => kyc.AMLRefId)
                .NotEmpty().WithCustomError(new RequireError());

            RuleFor(kyc => kyc.Reference)
                .NotEmpty().WithCustomError(new RequireError());
        }
    }
}
