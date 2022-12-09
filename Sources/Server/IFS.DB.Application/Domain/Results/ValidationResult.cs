using IFS.DB.Application.Domain.ErrorCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Results
{
    public class ValidationResult
    {
        public IList<Error> Errors { get; }

        public ValidationResult()
        {
            Errors = new List<Error>();
        }

        public ValidationResult(IList<Error> errors)
        {
            Errors = errors;
        }

        public bool IsValid
        {
            get { return Errors != null && Errors.Count() == 0; }
        }
    }
}
