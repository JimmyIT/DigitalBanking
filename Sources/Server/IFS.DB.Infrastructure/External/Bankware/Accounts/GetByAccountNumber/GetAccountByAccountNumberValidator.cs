using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.External.Bankware.Accounts.GetByAccountNumber
{
    public interface IAccountGetByAccountNumberValidator
    {
        ValidationResult Validate(string accountNumber);
    }

    public class GetAccountByAccountNumberValidator : IAccountGetByAccountNumberValidator
    {
        public ValidationResult Validate(string accountNumber)
        {
            IList<Error> errors = new List<Error>();

            if (string.IsNullOrEmpty(accountNumber))
            {
                errors.Add(new RequireError("Account Number"));
            }

            return new ValidationResult(errors);
        }
    }
}
