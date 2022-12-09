using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.UpdateRegisterOnboarding
{
    public interface IUpdateRegisterOnboardingAccountApplicationHandler : IBaseHandler
    {
        Task<ActionResult<UpdateRegisterOnboardingAccountApplicationResponse>> DoActionAsync(UpdateRegisterOnboardingAccountApplicationRequest onBoarding);
    }

    public class UpdateRegisterOnboardingAccountApplicationHandler : BaseHandler, IUpdateRegisterOnboardingAccountApplicationHandler
    {
        private readonly IUpdateRegisterOnboardingAccountApplicationValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public UpdateRegisterOnboardingAccountApplicationHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IUpdateRegisterOnboardingAccountApplicationValidator validator,
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public async Task<ActionResult<UpdateRegisterOnboardingAccountApplicationResponse>> DoActionAsync(UpdateRegisterOnboardingAccountApplicationRequest onBoarding)
        {
            ActionResult<UpdateRegisterOnboardingAccountApplicationResponse> result = new ActionResult<UpdateRegisterOnboardingAccountApplicationResponse>()
            {
                Result = new UpdateRegisterOnboardingAccountApplicationResponse() { ApplicationId = onBoarding.ApplicationId }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(onBoarding);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Get Account Application
            AccountApplication accAppEntity = await _AccountApplicationRepo.GetByIdAsync(onBoarding.ApplicationId);
            accAppEntity.LatestStep = onBoarding.LatestStep > accAppEntity.LatestStep.GetValueOrDefault(0) ? onBoarding.LatestStep : accAppEntity.LatestStep.GetValueOrDefault(0);
            accAppEntity.EmailAddress = !string.IsNullOrEmpty(onBoarding.Communication.Email) ? onBoarding.Communication.Email : accAppEntity.EmailAddress;
            accAppEntity.MessageContent = JsonConvert.SerializeObject(onBoarding);

            //Update Account Application
            await _AccountApplicationRepo.UpdateAsync(accAppEntity);

            result.Result.LatestStep = accAppEntity.LatestStep.GetValueOrDefault(0);

            return result;
        }
    }
}
