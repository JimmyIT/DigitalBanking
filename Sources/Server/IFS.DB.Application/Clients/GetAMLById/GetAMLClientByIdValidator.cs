using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Clients.GetAMLById
{
    public interface IGetAMLClientByIdValidator
    {
        ValidationResult Validate(string amlRefId);
    }

    public class GetAMLClientByIdValidator : IGetAMLClientByIdValidator
    {
        public ValidationResult Validate(string amlRefId)
        {
            IList<Error> errors = new List<Error>();

            if (string.IsNullOrEmpty(amlRefId))
            {
                errors.Add(new RequireError("AML Ref Id"));
            }

            return new ValidationResult(errors);
        }
    }
}
