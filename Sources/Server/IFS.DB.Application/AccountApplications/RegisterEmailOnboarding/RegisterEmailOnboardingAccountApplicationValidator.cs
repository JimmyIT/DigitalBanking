using FluentValidation;
using IFS.DB.Application.Common.Bankware.Clients;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Bankware.Clients.CheckEmailExist;
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

namespace IFS.DB.Application.AccountApplications.RegisterEmailOnboarding
{
    public interface IRegisterEmailOnboardingAccountApplicationValidator
    {
        ValidationResult Validate(RegisterEmailOnboardingAccountApplicationRequest email);
    }

    public class RegisterEmailOnboardingAccountApplicationValidator : FluentValidatorBase<RegisterEmailOnboardingAccountApplicationRequest>, IRegisterEmailOnboardingAccountApplicationValidator
    {
        private readonly IAccountApplicationRepo _AccountApplicationRepo;
        private readonly ICheckEmailExistService _CheckEmailExistSvc;

        public RegisterEmailOnboardingAccountApplicationValidator(IErrorMessageService errorMessageSvc,
            IAccountApplicationRepo accountApplicationRepo,
            ICheckEmailExistService checkEmailExistSvc)
            : base(errorMessageSvc)
        {
            _AccountApplicationRepo = accountApplicationRepo;
            _CheckEmailExistSvc = checkEmailExistSvc;
        }

        public new ValidationResult Validate(RegisterEmailOnboardingAccountApplicationRequest email)
        {
            FvResult result = base.Validate(email);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(email => email.Email)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(email => email.Email)
                .Must((obj, email) => IsNewEmail(email))
                .WithCustomError(new ExistedError());
        }

        private bool IsNewEmail(string email)
        {
            bool result = false;

            //Check Exist Account Application. If exist, check status must be equal CreateNew, FirstTimeSent, EmailResent, LinkExpired
            AccountApplication accAppEntity = _AccountApplicationRepo.GetByEmailAsync(email).GetAwaiter().GetResult();
            if (accAppEntity != null)
                if (accAppEntity.Status != (int)AccountApplicationStatusEnum.CreateNew && accAppEntity.Status != (int)AccountApplicationStatusEnum.FirstTimeSent && accAppEntity.Status != (int)AccountApplicationStatusEnum.EmailResent && accAppEntity.Status != (int)AccountApplicationStatusEnum.LinkExpired)
                    return result;

            //Check Email Exist in Bankware
            CheckEmailExistRequest emailRequest = new CheckEmailExistRequest() { EmailAddress = email };

            ActionResult<CheckEmailExistResponse> emailResponse = _CheckEmailExistSvc.DoActionAsync(emailRequest).GetAwaiter().GetResult();
            if (emailResponse.IsNotError)
                result = !emailResponse.Result.IsExist;

            return result;
        }
    }
}
