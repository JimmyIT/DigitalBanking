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

namespace IFS.DB.Application.AccountApplications.GetById
{
    public interface IGetAccountApplicationByIdHandler : IBaseHandler
    {
        Task<ActionResult<GetAccountApplicationByIdResponse>> DoActionAsync(string id);
    }

    public class GetAccountApplicationByIdHandler : BaseHandler, IGetAccountApplicationByIdHandler
    {
        private readonly IGetAccountApplicationByIdValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public GetAccountApplicationByIdHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IGetAccountApplicationByIdValidator validator,
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public async Task<ActionResult<GetAccountApplicationByIdResponse>> DoActionAsync(string id)
        {
            ActionResult<GetAccountApplicationByIdResponse> result = new ActionResult<GetAccountApplicationByIdResponse>()
            {
                Result = new GetAccountApplicationByIdResponse() { ApplicationId = new Guid(id) }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(id);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Config Mapping
            GetAccountApplicationByIdResponse.ConfigMapping();

            //Get Data
            AccountApplication accAppEntity = await _AccountApplicationRepo.GetByIdAsync(new Guid(id));
            result.Result = accAppEntity.Adapt<GetAccountApplicationByIdResponse>();

            return result;
        }
    }
}
