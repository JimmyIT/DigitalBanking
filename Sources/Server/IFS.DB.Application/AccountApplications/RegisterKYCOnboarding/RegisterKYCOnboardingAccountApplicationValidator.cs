using FluentValidation;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FvResult = FluentValidation.Results.ValidationResult;

namespace IFS.DB.Application.AccountApplications.RegisterKYCOnboarding
{
    public interface IRegisterKYCOnboardingAccountApplicationValidator
    {
        ValidationResult Validate(RegisterKYCOnboardingAccountApplicationRequest onboarding);
    }

    public class RegisterKYCOnboardingAccountApplicationValidator : FluentValidatorBase<RegisterKYCOnboardingAccountApplicationRequest>, IRegisterKYCOnboardingAccountApplicationValidator
    {
        public RegisterKYCOnboardingAccountApplicationValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        {
        }

        public new ValidationResult Validate(RegisterKYCOnboardingAccountApplicationRequest onboarding)
        {
            FvResult result = base.Validate(onboarding);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(onboarding => onboarding.LinkId)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(onboarding => onboarding.FirstName)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(onboarding => onboarding.LastName)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(onboarding => onboarding.Email)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(onboarding => onboarding.BackCallBackURL)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(onboarding => onboarding.SubmitCallBackURL)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
