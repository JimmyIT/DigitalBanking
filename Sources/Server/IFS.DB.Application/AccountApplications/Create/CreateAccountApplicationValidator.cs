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

namespace IFS.DB.Application.AccountApplications.Create
{
    public interface ICreateAccountApplicationValidator
    {
        ValidationResult Validate(CreateAccountApplicationRequest accApp);
    }

    public class CreateAccountApplicationValidator : FluentValidatorBase<CreateAccountApplicationRequest>, ICreateAccountApplicationValidator
    {
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public CreateAccountApplicationValidator(IErrorMessageService errorMessageSvc,
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc)
        {
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public new ValidationResult Validate(CreateAccountApplicationRequest accApp)
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
                .Must((obj, id) => IsNewGuid(id))
                .WithCustomError(new ExistedError());

            RuleFor(accApp => accApp.EmailAddress)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(accApp => accApp.EmailAddress)
                .Must((obj, email) => IsNewEmail(email))
                .WithCustomError(new ExistedError());

            RuleFor(accApp => accApp.SessionId)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }

        private bool IsNewGuid(Guid id)
        {
            AccountApplication entity = _AccountApplicationRepo.GetByIdAsync(id).GetAwaiter().GetResult();
            return entity == null;
        }

        private bool IsNewEmail(string email)
        {
            AccountApplication entity = _AccountApplicationRepo.GetByEmailAsync(email).GetAwaiter().GetResult();
            return entity == null;
        }
    }
}
