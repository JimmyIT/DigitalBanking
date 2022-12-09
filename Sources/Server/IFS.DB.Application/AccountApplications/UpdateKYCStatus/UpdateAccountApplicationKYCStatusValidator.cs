using FluentValidation;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
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

namespace IFS.DB.Application.AccountApplications.UpdateKYCStatus
{
    public interface IUpdateAccountApplicationKYCStatusValidator
    {
        ValidationResult Validate(UpdateAccountApplicationKYCStatusRequest accApp);
    }

    public class UpdateAccountApplicationKYCStatusValidator : FluentValidatorBase<UpdateAccountApplicationKYCStatusRequest>, IUpdateAccountApplicationKYCStatusValidator
    {
        public UpdateAccountApplicationKYCStatusValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        {
        }

        public new ValidationResult Validate(UpdateAccountApplicationKYCStatusRequest accApp)
        {
            FvResult result = base.Validate(accApp);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(accApp => accApp.ApplicationId)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(accApp => accApp.Status)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(accApp => accApp.Status)
                .Must((obj, status) => IsKYCStatus(status))
                .WithCustomError(new InvalidDataError());
        }

        private bool IsKYCStatus(AccountApplicationStatusEnum status)
        {
            return (status == AccountApplicationStatusEnum.AMLTracKYCApproved || status == AccountApplicationStatusEnum.AMLTracKYCRejected);
        }
    }
}
