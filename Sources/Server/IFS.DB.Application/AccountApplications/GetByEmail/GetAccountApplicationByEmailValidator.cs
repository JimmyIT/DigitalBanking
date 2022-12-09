using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.GetByEmail
{
    public interface IGetAccountApplicationByEmailValidator
    {
        ValidationResult Validate(string emailAddress);
    }

    public class GetAccountApplicationByEmailValidator : IGetAccountApplicationByEmailValidator
    {
        public ValidationResult Validate(string emailAddress)
        {
            IList<Error> errors = new List<Error>();

            if (string.IsNullOrEmpty(emailAddress))
            {
                errors.Add(new RequireError("Email Address"));
            }

            return new ValidationResult(errors);
        }
    }
}
