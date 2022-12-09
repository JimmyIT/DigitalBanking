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

namespace IFS.DB.Application.Documents.GetShuftiProVerificationURL
{
    public interface IGetShuftiProVerificationURLValidator
    {
        ValidationResult Validate(GetShuftiProVerificationURLRequest model);
    }

    public class GetShuftiProVerificationURLValidator : FluentValidatorBase<GetShuftiProVerificationURLRequest>, IGetShuftiProVerificationURLValidator
    {
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public GetShuftiProVerificationURLValidator(IErrorMessageService errorMessageSvc,
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc)
        {
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public new ValidationResult Validate(GetShuftiProVerificationURLRequest model)
        {
            FvResult result = base.Validate(model);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(model => model.ApplicationId)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(model => model.ApplicationId)
                .Must((obj, id) => IsExistGuid(id))
                .WithCustomError(new NotExistedError());
        }

        private bool IsExistGuid(Guid id)
        {
            AccountApplication entity = _AccountApplicationRepo.GetByIdAsync(id).GetAwaiter().GetResult();
            return entity != null;
        }
    }
}
