using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.External.AMLtrac.Customers.GetLinkId
{
    public interface IGetCustomerLinkIdValidator
    {
        ValidationResult Validate(string amltracRefId);
    }

    public class GetCustomerLinkIdValidator : IGetCustomerLinkIdValidator
    {
        public ValidationResult Validate(string amltracRefId)
        {
            IList<Error> errors = new List<Error>();

            if (string.IsNullOrEmpty(amltracRefId))
            {
                errors.Add(new RequireError("AMLtracRefId"));
            }

            return new ValidationResult(errors);
        }
    }
}
