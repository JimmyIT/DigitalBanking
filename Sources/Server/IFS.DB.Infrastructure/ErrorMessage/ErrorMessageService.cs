using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.ErrorMessage
{
    public class ErrorMessageService : IErrorMessageService
    {
        private readonly IStringProvider _StringProvider;
        private readonly IAPIErrorResourceRepo _ApiErrorResourceRepo;

        public ErrorMessageService(IStringProvider stringProvider,
            IAPIErrorResourceRepo apiErrorResourceRepo)
        {
            _StringProvider = stringProvider;
            _ApiErrorResourceRepo = apiErrorResourceRepo;
        }

        public async Task<Error> CreateAsync(string errorCode)
        {
            Error result = new Error()
            {
                Code = errorCode,
                Message = (await _ApiErrorResourceRepo.GetByKeyAsync(errorCode))?.Message
            };

            return result;
        }

        public async Task<Error> CreateAsync(string errorCode, string additionalInfo)
        {
            Error result = new Error()
            {
                Code = errorCode,
                Message = (await _ApiErrorResourceRepo.GetByKeyAsync(errorCode))?.Message,
                AdditionalInfo = additionalInfo
            };

            return result;
        }

        public async Task<Error> CreateInternalServerErrorAsync(Exception ex)
        {
            Error result = new Error()
            {
                Code = ErrorMessageCode.InternalServerError,
                Message = (await _ApiErrorResourceRepo.GetByKeyAsync(ErrorMessageCode.InternalServerError))?.Message,
                AdditionalInfo = ex.ToString(),
                Reference = _StringProvider.NewGuid().ToString()
            };

            return result;
        }

        public async Task<Error> CreateInternalServerErrorAsync(string msg)
        {
            Error result = new Error()
            {
                Code = ErrorMessageCode.InternalServerError,
                Message = (await _ApiErrorResourceRepo.GetByKeyAsync(ErrorMessageCode.InternalServerError))?.Message,
                AdditionalInfo = msg,
                Reference = _StringProvider.NewGuid().ToString()
            };

            return result;
        }
    }
}
