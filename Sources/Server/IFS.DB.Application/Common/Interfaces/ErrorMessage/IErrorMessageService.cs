using IFS.DB.Application.Domain.ErrorCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.ErrorMessage
{
    public interface IErrorMessageService
    {
        Task<Error> CreateAsync(string errorCode);
        Task<Error> CreateAsync(string errorCode, string additionalInfo);
        Task<Error> CreateInternalServerErrorAsync(Exception ex);
        Task<Error> CreateInternalServerErrorAsync(string msg);
    }
}
