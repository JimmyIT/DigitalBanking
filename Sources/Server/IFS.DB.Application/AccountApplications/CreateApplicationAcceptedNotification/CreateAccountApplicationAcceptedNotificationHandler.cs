using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.CreateApplicationAcceptedNotification
{
    public interface ICreateAccountApplicationAcceptedNotificationHandler : IBaseHandler
    {
        Task<ActionResult<CreateAccountApplicationAcceptedNotificationResponse>> DoActionAsync(CreateAccountApplicationAcceptedNotificationRequest appNotification);
    }

    public class CreateAccountApplicationAcceptedNotificationHandler : BaseHandler, ICreateAccountApplicationAcceptedNotificationHandler
    {
        private readonly ICreateAccountApplicationAcceptedNotificationValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;
        private readonly IMessageQueueRepo _MessageQueueRepo;
        private readonly IParameterService _ParameterSvc;
        private readonly IDateTimeProvider _DateTimeProvider;
        private readonly IStringProvider _StringProvider;

        public CreateAccountApplicationAcceptedNotificationHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator,
            ICreateAccountApplicationAcceptedNotificationValidator validator,
            IAccountApplicationRepo accountApplicationRepo,
            IMessageQueueRepo messageQueueRepo,
            IParameterService parameterSvc,
            IDateTimeProvider dateTimeProvider,
            IStringProvider stringProvider)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
            _MessageQueueRepo = messageQueueRepo;
            _ParameterSvc = parameterSvc;
            _DateTimeProvider = dateTimeProvider;
            _StringProvider = stringProvider;
        }

        public async Task<ActionResult<CreateAccountApplicationAcceptedNotificationResponse>> DoActionAsync(CreateAccountApplicationAcceptedNotificationRequest appNotification)
        {
            ActionResult<CreateAccountApplicationAcceptedNotificationResponse> result = new ActionResult<CreateAccountApplicationAcceptedNotificationResponse>()
            {
                Result = new CreateAccountApplicationAcceptedNotificationResponse() { ApplicationId = appNotification.ApplicationId }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(appNotification);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Create Account Applicaiton
            AccountApplicationStatusEnum accAppStatus = appNotification.NotificationType switch
            {
                NotificationTypeEnum.Email => AccountApplicationStatusEnum.SendApplicationAcceptedEmail,
                NotificationTypeEnum.SMS => AccountApplicationStatusEnum.SendApplicationAcceptedSMS,
                NotificationTypeEnum.Both => AccountApplicationStatusEnum.SendApplicationAcceptedNotification,
                _ => AccountApplicationStatusEnum.SendApplicationAcceptedEmail
            };

            AccountApplication accAppEntity = new AccountApplication()
            {
                UniqueId = appNotification.ApplicationId,
                DateSubmitted = _DateTimeProvider.Now(),
                EmailAddress = !string.IsNullOrEmpty(appNotification.Communication.Email) ? appNotification.Communication.Email : appNotification.ApplicationId.ToString(),
                SessionId = _StringProvider.NewGuid(),
                Status = (int)accAppStatus,
                ExpiryDate = _DateTimeProvider.Now(),
                ExistingAccountHolder = false,
                DebitCardRequired = false,
                CreditCardRequired = false,
                OwnershipType = string.Empty,
                NumberofSignatories = 0,
                AllocatedClientId = appNotification.ClientNumber,
                MessageContent = JsonConvert.SerializeObject(appNotification)
            };

            //Create Message
            Mqmessage mqmessageEntity = new Mqmessage()
            {
                MessageContent = JsonConvert.SerializeObject(appNotification),
                Direction = DirectionConst.OnBoarding,
                MessageType = (int)MessageTypeEnum.OnBoarding,
                ActionType = (int)ActionTypeEnum.Insert,
                Status = (int)MQMessageStatusEnum.Pending,
                AdditionalInfo1 = appNotification.ApplicationId.ToString(),
                CreatedOn = _DateTimeProvider.Now()
            };

            //Insert Database
            IDbContextTransaction transaction = _AccountApplicationRepo.DBContext.Database.BeginTransaction();

            try
            {
                //Insert Account Application
                await _AccountApplicationRepo.InsertAsync(accAppEntity);

                //Insert Messgae to Queue
                await _MessageQueueRepo.InsertAsync(mqmessageEntity, string.Empty, string.Empty);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

            return result;
        }
    }
}
