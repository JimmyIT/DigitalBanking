using FluentValidation;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
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

namespace IFS.DB.Application.AccountApplications.ConfirmOnboarding
{
    public interface IConfirmOnboardingAccountApplicationValidator
    {
        ValidationResult Validate(ConfirmOnboardingAccountApplicationRequest onboarding);
    }

    public class ConfirmOnboardingAccountApplicationValidator : FluentValidatorBase<ConfirmOnboardingAccountApplicationRequest>, IConfirmOnboardingAccountApplicationValidator
    {
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public ConfirmOnboardingAccountApplicationValidator(IErrorMessageService errorMessageSvc,
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc)
        {
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public new ValidationResult Validate(ConfirmOnboardingAccountApplicationRequest onboarding)
        {
            FvResult result = base.Validate(onboarding);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(onboarding => onboarding.ApplicationId)
                .NotEmpty().WithCustomError(new RequireError())
                .Must((obj, id) => IsExistGuid(id)).WithCustomError(new NotExistedError());
        }

        private bool IsExistGuid(Guid applicationId)
        {
            AccountApplication entity = _AccountApplicationRepo.GetByIdAsync(applicationId).GetAwaiter().GetResult();
            return entity != null;
        }
    }
}
