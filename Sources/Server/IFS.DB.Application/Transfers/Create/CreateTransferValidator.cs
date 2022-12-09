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

namespace IFS.DB.Application.Transfers.Create
{
    public interface ICreateTransferValidator
    {
        ValidationResult Validate(CreateTransferRequest transfer);
    }

    public class CreateTransferValidator : FluentValidatorBase<CreateTransferRequest>, ICreateTransferValidator
    {
        public CreateTransferValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(CreateTransferRequest transfer)
        {
            FvResult result = base.Validate(transfer);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(transfer => transfer.iBankReference)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
