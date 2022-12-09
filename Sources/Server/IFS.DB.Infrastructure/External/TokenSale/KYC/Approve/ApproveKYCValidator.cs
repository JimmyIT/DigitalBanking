using FluentValidation;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Domain.TokenSale.KYC.Approve;
using IFS.DB.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FvResult = FluentValidation.Results.ValidationResult;

namespace IFS.DB.Infrastructure.External.TokenSale.KYC.Approve
{
    public interface IApproveKYCValidator
    {
        ValidationResult Validate(ApproveKYCRequest kyc);
    }

    public class ApproveKYCValidator : FluentValidatorBase<ApproveKYCRequest>, IApproveKYCValidator
    {
        public ApproveKYCValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(ApproveKYCRequest kyc)
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
        }
    }
}
