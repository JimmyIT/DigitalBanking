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

namespace IFS.DB.Application.Clients.CreateAML
{
    public interface ICreateAMLClientValidator
    {
        ValidationResult Validate(CreateAMLClientRequest customer);
    }

    public class CreateAMLClientValidator : FluentValidatorBase<CreateAMLClientRequest>, ICreateAMLClientValidator
    {
        public CreateAMLClientValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(CreateAMLClientRequest customer)
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
