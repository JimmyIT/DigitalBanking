using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Parameters.GetByKey
{
    public interface IGetParameterByKeyValidator
    {
        ValidationResult Validate(string paramKey);
    }

    public class GetParameterByKeyValidator : IGetParameterByKeyValidator
    {
        public ValidationResult Validate(string paramKey)
        {
            IList<Error> errors = new List<Error>();

            if (string.IsNullOrEmpty(paramKey))
            {
                errors.Add(new RequireError("Param Key"));
            }

            return new ValidationResult(errors);
        }
    }
}
