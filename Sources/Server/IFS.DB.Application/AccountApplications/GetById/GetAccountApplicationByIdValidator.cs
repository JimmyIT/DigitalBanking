using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.GetById
{
    public interface IGetAccountApplicationByIdValidator
    {
        ValidationResult Validate(string id);
    }

    public class GetAccountApplicationByIdValidator : IGetAccountApplicationByIdValidator
    {
        public ValidationResult Validate(string id)
        {
            IList<Error> errors = new List<Error>();

            if (string.IsNullOrEmpty(id))
            {
                errors.Add(new RequireError("Id"));
            }

            return new ValidationResult(errors);
        }
    }
}
