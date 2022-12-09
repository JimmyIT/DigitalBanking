using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Mapster;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Messages.Create
{
    public interface ICreateMessageHandler : IBaseHandler
    {
        Task<ActionResult<CreateMessageResponse>> DoActionAsync(CreateMessageRequest message);
    }

    public class CreateMessageHandler : BaseHandler, ICreateMessageHandler
    {
        private readonly ICreateMessageValidator _Validator;
        private readonly IMessageQueueRepo _MessageQueueRepo;
        private readonly IDateTimeProvider _DateTimeProvider;

        public CreateMessageHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ICreateMessageValidator validator,
            IMessageQueueRepo messageQueueRepo,
            IDateTimeProvider dateTimeProvider)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _MessageQueueRepo = messageQueueRepo;
            _DateTimeProvider = dateTimeProvider;
        }

        public async Task<ActionResult<CreateMessageResponse>> DoActionAsync(CreateMessageRequest message)
        {
            ActionResult<CreateMessageResponse> result = new ActionResult<CreateMessageResponse>()
            {
                Result = new CreateMessageResponse()
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(message);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Mapping to Entity
            CreateMessageRequest.ConfigMapping();
            Mqmessage messageEntity = message.Adapt<Mqmessage>();
            messageEntity.ActionType = (int)ActionTypeEnum.Insert;
            messageEntity.Status = (int)MQMessageStatusEnum.Pending;
            messageEntity.CreatedOn = _DateTimeProvider.Now();

            //Insert Message
            IDbContextTransaction transaction = _MessageQueueRepo.DBContext.Database.BeginTransaction();

            try
            {
                await _MessageQueueRepo.InsertAsync(messageEntity, string.Empty, message.Note);

                await transaction.CommitAsync();

                result.Result.MessageId = messageEntity.MessageId;
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
