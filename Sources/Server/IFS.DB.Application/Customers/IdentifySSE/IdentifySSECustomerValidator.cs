using FluentValidation;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FvResult = FluentValidation.Results.ValidationResult;

namespace IFS.DB.Application.Customers.IdentifySSE
{
    public interface IIdentifySSECustomerValidator
    {
        ValidationResult Validate(IdentifySSECustomerRequest customer);
    }

    public class IdentifySSECustomerValidator : FluentValidatorBase<IdentifySSECustomerRequest>, IIdentifySSECustomerValidator
    {
        public IdentifySSECustomerValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        {
        }

        public new ValidationResult Validate(IdentifySSECustomerRequest customer)
        {
            FvResult result = base.Validate(customer);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(customer => customer.LogonId)
                .NotEmpty().WithCustomError(_ErrorMessageSvc.CreateAsync(ErrorMessageCode.LogonIdRequired).GetAwaiter().GetResult());

        }
    }
}
