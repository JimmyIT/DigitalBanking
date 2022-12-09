using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.Update
{
    public interface IUpdateAccountApplicationHandler : IBaseHandler
    {
        Task<ActionResult<UpdateAccountApplicationResponse>> DoActionAsync(UpdateAccountApplicationRequest accApp);
    }

    public class UpdateAccountApplicationHandler : BaseHandler, IUpdateAccountApplicationHandler
    {
        private readonly IUpdateAccountApplicationValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public UpdateAccountApplicationHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IUpdateAccountApplicationValidator validator,
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public async Task<ActionResult<UpdateAccountApplicationResponse>> DoActionAsync(UpdateAccountApplicationRequest accApp)
        {
            ActionResult<UpdateAccountApplicationResponse> result = new ActionResult<UpdateAccountApplicationResponse>()
            {
                Result = new UpdateAccountApplicationResponse() { ApplicationId = accApp.ApplicationId }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(accApp);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Get Detail Id
            AccountApplication entity = await _AccountApplicationRepo.GetByIdAsync(accApp.ApplicationId);

            //Config Mapping
            UpdateAccountApplicationRequest.ConfigMapping();

            //Map Model to Entity
            accApp.Adapt(entity);

            await _AccountApplicationRepo.UpdateAsync(entity);

            return result;
        }
    }
}
