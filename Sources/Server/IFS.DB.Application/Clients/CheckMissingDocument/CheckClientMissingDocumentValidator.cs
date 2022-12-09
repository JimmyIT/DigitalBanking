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

namespace IFS.DB.Application.Clients.CheckMissingDocument
{
    public interface ICheckClientMissingDocumentValidator
    {
        ValidationResult Validate(CheckClientMissingDocumentRequest client);
    }

    public class CheckClientMissingDocumentValidator : FluentValidatorBase<CheckClientMissingDocumentRequest>, ICheckClientMissingDocumentValidator
    {
        public CheckClientMissingDocumentValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(CheckClientMissingDocumentRequest client)
        {
            FvResult result = base.Validate(client);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(client => client.AMLtracRefId)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
