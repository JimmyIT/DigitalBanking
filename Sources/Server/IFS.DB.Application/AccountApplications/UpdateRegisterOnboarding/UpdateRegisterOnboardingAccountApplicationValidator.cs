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

namespace IFS.DB.Application.AccountApplications.UpdateRegisterOnboarding
{
    public interface IUpdateRegisterOnboardingAccountApplicationValidator
    {
        ValidationResult Validate(UpdateRegisterOnboardingAccountApplicationRequest accApp);
    }

    public class UpdateRegisterOnboardingAccountApplicationValidator : FluentValidatorBase<UpdateRegisterOnboardingAccountApplicationRequest>, IUpdateRegisterOnboardingAccountApplicationValidator
    {
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public UpdateRegisterOnboardingAccountApplicationValidator(IErrorMessageService errorMessageSvc,
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc)
        {
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public new ValidationResult Validate(UpdateRegisterOnboardingAccountApplicationRequest accApp)
        {
            FvResult result = base.Validate(accApp);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(accApp => accApp.ApplicationId)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(accApp => accApp.ApplicationId)
                .Must((obj, id) => IsExistGuid(id))
                .WithCustomError(new NotExistedError());

            RuleFor(accApp => accApp.EntityType)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(accApp => accApp.LatestStep)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(accApp => accApp.Communication.Email)
                .Must((obj, email) => IsNewEmail(email, obj.ApplicationId))
                .WithCustomError(new ExistedError());
        }

        private bool IsExistGuid(Guid id)
        {
            AccountApplication entity = _AccountApplicationRepo.GetByIdAsync(id).GetAwaiter().GetResult();
            return entity != null;
        }

        private bool IsNewEmail(string email, Guid id)
        {
            bool result = true;

            if (!string.IsNullOrEmpty(email))
            {
                AccountApplication accAppEntity = _AccountApplicationRepo.GetByEmailAsync(email).GetAwaiter().GetResult();
                if (accAppEntity != null)
                    result = accAppEntity.UniqueId == id;
            }

            return result;
        }
    }
}
