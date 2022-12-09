using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.GetBySessionId
{
    public interface IGetAccountApplicationBySessionIdHandler : IBaseHandler
    {
        Task<ActionResult<GetAccountApplicationBySessionIdResponse>> DoActionAsync(Guid sessionId);
    }

    public class GetAccountApplicationBySessionIdHandler : BaseHandler, IGetAccountApplicationBySessionIdHandler
    {
        private readonly IGetAccountApplicationBySessionIdValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public GetAccountApplicationBySessionIdHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IGetAccountApplicationBySessionIdValidator validator,
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public async Task<ActionResult<GetAccountApplicationBySessionIdResponse>> DoActionAsync(Guid sessionId)
        {
            ActionResult<GetAccountApplicationBySessionIdResponse> result = new ActionResult<GetAccountApplicationBySessionIdResponse>()
            {
                Result = new GetAccountApplicationBySessionIdResponse() { SessionId = sessionId }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(sessionId);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Config Mapping
            GetAccountApplicationBySessionIdResponse.ConfigMapping();

            //Get Data
            AccountApplication accAppEntity = await _AccountApplicationRepo.GetBySessionIdAsync(sessionId);
            result.Result = accAppEntity.Adapt<GetAccountApplicationBySessionIdResponse>();

            return result;
        }
    }
}
