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

namespace IFS.DB.Application.AccountApplications.UpdateStatus
{
    public interface IUpdateAccountApplicationStatusValidator
    {
        ValidationResult Validate(UpdateAccountApplicationStatusRequest accApp);
    }

    public class UpdateAccountApplicationStatusValidator : FluentValidatorBase<UpdateAccountApplicationStatusRequest>, IUpdateAccountApplicationStatusValidator
    {
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public UpdateAccountApplicationStatusValidator(IErrorMessageService errorMessageSvc,
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc)
        {
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public new ValidationResult Validate(UpdateAccountApplicationStatusRequest accApp)
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

            RuleFor(accApp => accApp.Status)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }

        private bool IsExistGuid(Guid id)
        {
            AccountApplication entity = _AccountApplicationRepo.GetByIdAsync(id).GetAwaiter().GetResult();
            return entity != null;
        }
    }
}
