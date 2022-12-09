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

namespace IFS.DB.Application.AccountApplications.GetByEmail
{
    public interface IGetAccountApplicationByEmailHandler : IBaseHandler
    {
        Task<ActionResult<GetAccountApplicationByEmailResponse>> DoActionAsync(string emailAddress);
    }

    public class GetAccountApplicationByEmailHandler : BaseHandler, IGetAccountApplicationByEmailHandler
    {
        private readonly IGetAccountApplicationByEmailValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public GetAccountApplicationByEmailHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator,
            IGetAccountApplicationByEmailValidator validator,
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public async Task<ActionResult<GetAccountApplicationByEmailResponse>> DoActionAsync(string emailAddress)
        {
            ActionResult<GetAccountApplicationByEmailResponse> result = new ActionResult<GetAccountApplicationByEmailResponse>()
            {
                Result = new GetAccountApplicationByEmailResponse() { EmailAddress = emailAddress }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(emailAddress);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Config Mapping
            GetAccountApplicationByEmailResponse.ConfigMapping();

            //Get Data
            AccountApplication accAppEntity = await _AccountApplicationRepo.GetByEmailAsync(emailAddress);
            result.Result = accAppEntity.Adapt<GetAccountApplicationByEmailResponse>();

            return result;
        }
    }
}
