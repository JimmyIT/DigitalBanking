﻿using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FvResult = FluentValidation.Results.ValidationResult;

namespace IFS.DB.Application.Customers.CheckTwoFACode
{
    public interface ICheckTwoFACodeCustomerValidator
    {
        ValidationResult Validate(CheckTwoFACodeCustomerRequest customer);
    }

    public class CheckTwoFACodeCustomerValidator : FluentValidatorBase<CheckTwoFACodeCustomerRequest>, ICheckTwoFACodeCustomerValidator
    {
        public CheckTwoFACodeCustomerValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        {
        }

        public new ValidationResult Validate(CheckTwoFACodeCustomerRequest customer)
        {
            FvResult result = base.Validate(customer);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
        }
    }
}
