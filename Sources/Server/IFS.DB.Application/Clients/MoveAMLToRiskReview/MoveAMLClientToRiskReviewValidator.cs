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

namespace IFS.DB.Application.Clients.MoveAMLToRiskReview
{
    public interface IMoveAMLClientToRiskReviewValidator
    {
        ValidationResult Validate(MoveAMLClientToRiskReviewRequest client);
    }

    public class MoveAMLClientToRiskReviewValidator : FluentValidatorBase<MoveAMLClientToRiskReviewRequest>, IMoveAMLClientToRiskReviewValidator
    {
        public MoveAMLClientToRiskReviewValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(MoveAMLClientToRiskReviewRequest client)
        {
            FvResult result = base.Validate(client);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(client => client.AmlRefId)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
