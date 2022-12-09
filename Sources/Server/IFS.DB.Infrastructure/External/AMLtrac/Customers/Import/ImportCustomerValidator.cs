using FluentValidation;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.AMLtrac.Customers.Import;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FvResult = FluentValidation.Results.ValidationResult;

namespace IFS.DB.Infrastructure.External.AMLtrac.Customers.Import
{
    public interface IImportCustomerValidator
    {
        ValidationResult Validate(ImportCustomerRequest customer);
    }

    public class ImportCustomerValidator : FluentValidatorBase<ImportCustomerRequest>, IImportCustomerValidator
    {
        public ImportCustomerValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(ImportCustomerRequest customer)
        {
            FvResult result = base.Validate(customer);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(customer => customer.EmailAddress)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(customer => customer.DataItemID)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(customer => customer.DateSubmitted)
                .NotEmpty()
                .WithCustomError(new RequireError());

            //Persnal Info
            RuleFor(customer => customer.PersonalInfo.FirstName)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(customer => customer.PersonalInfo.LastName)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(customer => customer.PersonalInfo.DateOfBirth)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
