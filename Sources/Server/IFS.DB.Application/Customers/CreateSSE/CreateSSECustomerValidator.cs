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

namespace IFS.DB.Application.Customers.CreateSSE
{
    public interface ICreateSSECustomerValidator
    {
        ValidationResult Validate(CreateSSECustomerRequest customer);
    }

    public class CreateSSECustomerValidator : FluentValidatorBase<CreateSSECustomerRequest>, ICreateSSECustomerValidator
    {
        private readonly ICustomerRepo _CustomerRepo;
        private readonly IClientRepo _ClientRepo;

        public CreateSSECustomerValidator(IErrorMessageService errorMessageSvc,
            ICustomerRepo customerRepo,
            IClientRepo clientRepo)
            : base(errorMessageSvc)
        {
            _CustomerRepo = customerRepo;
            _ClientRepo = clientRepo;
        }

        public new ValidationResult Validate(CreateSSECustomerRequest customer)
        {
            FvResult result = base.Validate(customer);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(customer => customer.LogonID)
                .NotEmpty().WithCustomError(new RequireError())
                .Must((obj, logonId) => IsNewLogonId(logonId)).WithCustomError(new ExistedError());

            RuleFor(customer => customer.ClientNumber)
                .NotEmpty().WithCustomError(new RequireError())
                .Must((obj, clientNumber) => IsClientExist(clientNumber)).WithCustomError(new NotExistedError());
        }

        private bool IsNewLogonId(string logonId)
        {
            IBankCustomer entity = _CustomerRepo.GetByLogonId(logonId).GetAwaiter().GetResult();
            return entity == null;
        }

        private bool IsClientExist(string clientNumber)
        {
            Client entity = _ClientRepo.GetByClientNumberAsync(clientNumber).GetAwaiter().GetResult();
            return entity != null;
        }
    }
}
