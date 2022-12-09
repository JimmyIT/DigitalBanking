using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.UpdateKYCStatus
{
    public interface IUpdateAccountApplicationKYCStatusHandler : IBaseHandler
    {
        Task<ActionResult<UpdateAccountApplicationKYCStatusResponse>> DoActionAsync(UpdateAccountApplicationKYCStatusRequest accApp);
    }

    public class UpdateAccountApplicationKYCStatusHandler : BaseHandler, IUpdateAccountApplicationKYCStatusHandler
    {
        private readonly IUpdateAccountApplicationKYCStatusValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;
        private readonly IMessageQueueRepo _MessageQueueRepo;
        private readonly IParameterService _ParameterSvc;

        public UpdateAccountApplicationKYCStatusHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IUpdateAccountApplicationKYCStatusValidator validator,
            IAccountApplicationRepo accountApplicationRepo,
            IMessageQueueRepo messageQueueRepo,
            IParameterService parameterSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
            _MessageQueueRepo = messageQueueRepo;
            _ParameterSvc = parameterSvc;
        }

        public async Task<ActionResult<UpdateAccountApplicationKYCStatusResponse>> DoActionAsync(UpdateAccountApplicationKYCStatusRequest accApp)
        {
            ActionResult<UpdateAccountApplicationKYCStatusResponse> result = new ActionResult<UpdateAccountApplicationKYCStatusResponse>()
            {
                Result = new UpdateAccountApplicationKYCStatusResponse() { ApplicationId = accApp.ApplicationId }
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

            //Map directly status when run Tag Version
            OnboardingProductionEnum onboardingProduction = await _ParameterSvc.GetOnboardingProductionAsync();
            if (onboardingProduction == OnboardingProductionEnum.KYC || onboardingProduction == OnboardingProductionEnum.Tag)
                accApp.Status = accApp.Status switch
                {
                    AccountApplicationStatusEnum.AMLTracKYCApproved => AccountApplicationStatusEnum.NotifyTagClientApproved,
                    AccountApplicationStatusEnum.AMLTracKYCRejected => AccountApplicationStatusEnum.NotifyTagClientRejected,
                    _ => accApp.Status
                };

            //Map Model to Entity
            if (entity != null)
            {
                if (entity.Status == (int)AccountApplicationStatusEnum.WaitingAMLTracResponseKYC || entity.Status == (int)AccountApplicationStatusEnum.FailAutoApproveKYCInAMLTrac)
                {
                    entity.Status = (int)accApp.Status;

                    //Update Message Queue from Hold to Pending to continue process
                    IEnumerable<Mqmessage> lstMessage = await _MessageQueueRepo.GetMessageByAdditional1(accApp.ApplicationId.ToString());

                    //Update DB
                    IDbContextTransaction transaction = _MessageQueueRepo.DBContext.Database.BeginTransaction();

                    try
                    {
                        await _AccountApplicationRepo.UpdateAsync(entity);

                        if (lstMessage != null && lstMessage.Count() > 0)
                            await _MessageQueueRepo.UpdateStatusAsync(lstMessage.LastOrDefault().MessageId, MQMessageStatusEnum.Pending, string.Empty, string.Empty);

                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }

            return result;
        }
    }
}
