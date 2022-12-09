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

namespace IFS.DB.Application.Customers.UpdateSSE
{
    public interface IUpdateSSECustomerValidator
    {
        ValidationResult Validate(UpdateSSECustomerRequest customer);
    }

    public class UpdateSSECustomerValidator : FluentValidatorBase<UpdateSSECustomerRequest>, IUpdateSSECustomerValidator
    {
        private readonly ICustomerRepo _CustomerRepo;

        public UpdateSSECustomerValidator(IErrorMessageService errorMessageSvc,
            ICustomerRepo customerRepo)
            : base(errorMessageSvc)
        {
            _CustomerRepo = customerRepo;
        }

        public new ValidationResult Validate(UpdateSSECustomerRequest customer)
        {
            FvResult result = base.Validate(customer);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(customer => customer.LogonID)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(customer => customer.LogonID)
                .Must((obj, logonId) => IsLogonIdExist(logonId))
                .WithCustomError(new NotExistedError());
        }

        private bool IsLogonIdExist(string logonId)
        {
            IBankCustomer entity = _CustomerRepo.GetByLogonId(logonId).GetAwaiter().GetResult();
            return entity != null;
        }
    }
}
