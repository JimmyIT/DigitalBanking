using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Documents.GetShuftiProVerificationStatus
{
    public interface IGetShuftiProVerificationStatusValidator
    {
        ValidationResult Validate(string reference);
    }

    public class GetShuftiProVerificationStatusValidator : IGetShuftiProVerificationStatusValidator
    {
        public ValidationResult Validate(string reference)
        {
            IList<Error> errors = new List<Error>();

            if (string.IsNullOrEmpty(reference))
            {
                errors.Add(new RequireError("Reference"));
            }

            return new ValidationResult(errors);
        }
    }
}
