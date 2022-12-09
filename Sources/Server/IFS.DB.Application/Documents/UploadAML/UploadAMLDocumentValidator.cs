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

namespace IFS.DB.Application.Documents.UploadAML
{
    public interface IUploadAMLDocumentValidator
    {
        ValidationResult Validate(UploadAMLDocumentRequest document);
    }

    public class UploadAMLDocumentValidator : FluentValidatorBase<UploadAMLDocumentRequest>, IUploadAMLDocumentValidator
    {
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public UploadAMLDocumentValidator(IErrorMessageService errorMessageSvc,
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc)
        {
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public new ValidationResult Validate(UploadAMLDocumentRequest document)
        {
            FvResult result = base.Validate(document);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(document => document.ApplicationId)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(accApp => accApp.ApplicationId)
                .Must((obj, id) => IsExistGuid(id))
                .WithCustomError(new NotExistedError());

            RuleFor(document => document.AmlRefId)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(document => document.FileName)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(document => document.DocumentCode)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(document => document.Reference)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(document => document.ExpiryDate)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }

        private bool IsExistGuid(Guid applicationId)
        {
            AccountApplication entity = _AccountApplicationRepo.GetByIdAsync(applicationId).GetAwaiter().GetResult();
            return entity != null;
        }
    }
}
