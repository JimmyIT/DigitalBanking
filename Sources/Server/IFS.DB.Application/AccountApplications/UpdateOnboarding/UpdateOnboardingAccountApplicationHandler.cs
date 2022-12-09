using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Notification;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.UpdateOnboarding
{
    public interface IUpdateOnboardingAccountApplicationHandler : IBaseHandler
    {
        Task<ActionResult<UpdateOnboardingAccountApplicationResponse>> DoActionAsync(UpdateOnboardingAccountApplicationRequest onBoarding);
    }

    public class UpdateOnboardingAccountApplicationHandler : BaseHandler, IUpdateOnboardingAccountApplicationHandler
    {
        private readonly IUpdateOnboardingAccountApplicationValidator _Validator;
        private readonly IMessageQueueRepo _MessageQueueRepo;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;
        private readonly ICountRepo _CountRepo;
        private readonly IDateTimeProvider _DateTimeProvider;
        private readonly IEmailService _EmailSvc;

        public UpdateOnboardingAccountApplicationHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IUpdateOnboardingAccountApplicationValidator validator,
            IMessageQueueRepo messageQueueRepo,
            IAccountApplicationRepo accountApplicationRepo,
            ICountRepo countRepo,
            IDateTimeProvider dateTimeProvider,
            IEmailService emailSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _MessageQueueRepo = messageQueueRepo;
            _AccountApplicationRepo = accountApplicationRepo;
            _CountRepo = countRepo;
            _DateTimeProvider = dateTimeProvider;
            _EmailSvc = emailSvc;
        }

        public async Task<ActionResult<UpdateOnboardingAccountApplicationResponse>> DoActionAsync(UpdateOnboardingAccountApplicationRequest onBoarding)
        {
            ActionResult<UpdateOnboardingAccountApplicationResponse> result = new ActionResult<UpdateOnboardingAccountApplicationResponse>()
            {
                Result = new UpdateOnboardingAccountApplicationResponse() 
                {
                    ApplicationId = onBoarding.ApplicationId,
                    EmailAddress = onBoarding.Communication.Email 
                }
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

            //Custom Validate Document List

            //Get Account Application
            AccountApplication accAppEntity = await _AccountApplicationRepo.GetByIdAsync(onBoarding.ApplicationId);

            //Map Model to Entity
            accAppEntity.EmailAddress = onBoarding.Communication.Email;
            accAppEntity.MessageContent = JsonConvert.SerializeObject(onBoarding);
            accAppEntity.Reference = await _CountRepo.GetNextReferenceAsync(CountTypeConst.Onboarding, string.Empty, string.Empty, accAppEntity.TokenCompanyCode);

            //Check if just upload more required documents, set status upload document
            accAppEntity.Status = accAppEntity.FirstTimeKyc.GetValueOrDefault(true) ? (int)AccountApplicationStatusEnum.CreateDataInAMLTrac : (int)AccountApplicationStatusEnum.MoveToDataCaptureInAMLtrac;

            //Check if just upload more required documents, don't generate LogonId
            //accAppEntity.LogonId = accAppEntity.FirstTimeKyc.GetValueOrDefault(true) ?  await _CountRepo.GetNextReferenceAsync(CountTypeConst.Onboarding, string.Empty, string.Empty, accAppEntity.TokenCompanyCode) : accAppEntity.LogonId;

            IDbContextTransaction transaction = _AccountApplicationRepo.DBContext.Database.BeginTransaction();

            try
            {
                //Update Account Application
                await _AccountApplicationRepo.UpdateAsync(accAppEntity);

                //Insert Messgae to Queue
                Mqmessage mqmessageEntity = new Mqmessage()
                {
                    MessageContent = JsonConvert.SerializeObject(onBoarding),
                    Direction = DirectionConst.OnBoarding,
                    MessageType = (int)MessageTypeEnum.OnBoarding,
                    ActionType = (int)ActionTypeEnum.Insert,
                    Status = (int)MQMessageStatusEnum.Pending,
                    AdditionalInfo1 = onBoarding.ApplicationId.ToString(),
                    CreatedOn = _DateTimeProvider.Now()
                };

                await _MessageQueueRepo.InsertAsync(mqmessageEntity, string.Empty, string.Empty);

                transaction.Commit();

                result.Result.Reference = accAppEntity.Reference;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

            //Send mail Thankyou
            await SendMail(accAppEntity.EmailAddress, accAppEntity.Reference);

            return result;
        }

        private async Task SendMail(string email, string reference)
        {
            string emailSubject = "Registration Confirmation";
            string emailContent = SetEmailTemplate(reference);

            await _EmailSvc.SendMailAsync(emailSubject, email, emailContent);
        }

        private string SetEmailTemplate(string reference)
        {
            string result = string.Empty;

            IDictionary context = new Hashtable();
            context.Add("Reference", reference);
            result = _EmailSvc.GetEmailContent(context, EmailTemplateConst.ThankYouRegisterOnboarding);

            return result;
        }
    }
}
