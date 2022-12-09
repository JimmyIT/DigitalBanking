using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore.Storage;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;

namespace IFS.DB.Application.AccountApplications.ConfirmOnboarding
{
    public interface IConfirmOnboardingAccountApplicationHandler : IBaseHandler
    {
        Task<ActionResult<ConfirmOnboardingAccountApplicationResponse>> DoActionAsync(ConfirmOnboardingAccountApplicationRequest onboarding);
    }

    public class ConfirmOnboardingAccountApplicationHandler : BaseHandler, IConfirmOnboardingAccountApplicationHandler
    {
        private readonly IConfirmOnboardingAccountApplicationValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;
        private readonly IMessageQueueRepo _MessageQueueRepo;

        public ConfirmOnboardingAccountApplicationHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator,
            IConfirmOnboardingAccountApplicationValidator validator,
            IAccountApplicationRepo accountApplicationRepo,
            IMessageQueueRepo messageQueueRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
            _MessageQueueRepo = messageQueueRepo;
        }

        public async Task<ActionResult<ConfirmOnboardingAccountApplicationResponse>> DoActionAsync(ConfirmOnboardingAccountApplicationRequest onboarding)
        {
            ActionResult<ConfirmOnboardingAccountApplicationResponse> result = new ActionResult<ConfirmOnboardingAccountApplicationResponse>()
            {
                Result = new ConfirmOnboardingAccountApplicationResponse() { Success = false }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(onboarding);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Get Account Application Info
            AccountApplication entity = await _AccountApplicationRepo.GetByIdAsync(onboarding.ApplicationId);

            entity.TransactionConfirmed = true;
            entity.Status = (int)AccountApplicationStatusEnum.MoveToRiskReviewInAMLtrac;

            //Update Message Queue from Hold to Pending to continue process
            IEnumerable<Mqmessage> lstMessage = await _MessageQueueRepo.GetMessageByAdditional1(onboarding.ApplicationId.ToString());

            //Update DB
            IDbContextTransaction transaction = _MessageQueueRepo.DBContext.Database.BeginTransaction();

            try
            {
                await _AccountApplicationRepo.UpdateAsync(entity);

                if (lstMessage != null && lstMessage.Count() > 0)
                    await _MessageQueueRepo.UpdateStatusAsync(lstMessage.LastOrDefault().MessageId, MQMessageStatusEnum.Pending, string.Empty, string.Empty);

                result.Result.Success = true;

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

            return result;
        }
    }
}
