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

namespace IFS.DB.Application.Clients.ApproveAML
{
    public interface IApproveAMLClientValidator
    {
        ValidationResult Validate(ApproveAMLClientRequest client);
    }

    public class ApproveAMLClientValidator : FluentValidatorBase<ApproveAMLClientRequest>, IApproveAMLClientValidator
    {
        public ApproveAMLClientValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(ApproveAMLClientRequest client)
        {
            FvResult result = base.Validate(client);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(client => client.ApplicationId)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
