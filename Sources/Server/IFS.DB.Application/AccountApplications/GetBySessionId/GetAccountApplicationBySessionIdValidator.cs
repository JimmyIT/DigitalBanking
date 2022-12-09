using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.GetBySessionId
{
    public interface IGetAccountApplicationBySessionIdValidator
    {
        ValidationResult Validate(Guid sessionId);
    }

    public class GetAccountApplicationBySessionIdValidator : IGetAccountApplicationBySessionIdValidator
    {
        public ValidationResult Validate(Guid sessionId)
        {
            IList<Error> errors = new List<Error>();

            if (string.IsNullOrEmpty(sessionId.ToString()))
            {
                errors.Add(new RequireError("SessionId"));
            }

            return new ValidationResult(errors);
        }
    }
}
