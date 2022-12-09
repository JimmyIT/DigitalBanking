using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Results;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Messages.UpdateStatus
{
    public interface IUpdateMessageStatusHandler : IBaseHandler
    {
        Task<ActionResult<UpdateMessageStatusResponse>> DoActionAsync(UpdateMessageStatusRequest message);
    }

    public class UpdateMessageStatusHandler : BaseHandler, IUpdateMessageStatusHandler
    {
        private readonly IUpdateMessageStatusValidator _Validator;
        private readonly IMessageQueueRepo _MessageQueueRepo;

        public UpdateMessageStatusHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IUpdateMessageStatusValidator validator,
            IMessageQueueRepo messageQueueRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _MessageQueueRepo = messageQueueRepo;
        }

        public async Task<ActionResult<UpdateMessageStatusResponse>> DoActionAsync(UpdateMessageStatusRequest message)
        {
            ActionResult<UpdateMessageStatusResponse> result = new ActionResult<UpdateMessageStatusResponse>()
            {
                Result = new UpdateMessageStatusResponse() { MessageId = message.MessageId }
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

            //Update Status
            IDbContextTransaction transaction = _MessageQueueRepo.DBContext.Database.BeginTransaction();

            try
            {
                await _MessageQueueRepo.UpdateStatusAsync(message.MessageId, message.Status, message.Note, message.ErrorMessage);

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
