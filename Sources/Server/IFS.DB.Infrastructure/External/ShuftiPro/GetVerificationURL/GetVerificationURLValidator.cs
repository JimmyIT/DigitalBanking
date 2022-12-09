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

using Domain = IFS.DB.Application.Domain.ShuftiPro.GetVerificationURL;
using FvResult = FluentValidation.Results.ValidationResult;

namespace IFS.DB.Infrastructure.External.ShuftiPro.GetVerificationURL
{
    public interface IGetVerificationURLValidator
    {
        ValidationResult Validate(Domain.GetVerificationURLRequest request);
    }

    public class GetVerificationURLValidator : FluentValidatorBase<Domain.GetVerificationURLRequest>, IGetVerificationURLValidator
    {
        public GetVerificationURLValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(Domain.GetVerificationURLRequest model)
        {
            FvResult result = base.Validate(model);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(model => model.Reference)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(model => model.RedirectURL)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
