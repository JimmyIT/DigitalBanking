using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Messages.GetByStatusAndDirection
{
    public interface IGetMessageByStatusAndDirectionHandler : IBaseHandler
    {
        Task<ActionResult<IEnumerable<GetMessageByStatusAndDirectionResponse>>> DoActionAsync(MQMessageStatusEnum status, string direction);
    }

    public class GetMessageByStatusAndDirectionHandler : BaseHandler, IGetMessageByStatusAndDirectionHandler
    {
        private readonly IMessageQueueRepo _MessageQueueRepo;

        public GetMessageByStatusAndDirectionHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IMessageQueueRepo messageQueueRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _MessageQueueRepo = messageQueueRepo;
        }

        public async Task<ActionResult<IEnumerable<GetMessageByStatusAndDirectionResponse>>> DoActionAsync(MQMessageStatusEnum status, string direction)
        {
            //Config Mapping
            GetMessageByStatusAndDirectionResponse.ConfigMapping();

            //Get Data
            IEnumerable<Mqmessage> lst = await _MessageQueueRepo.GetMessageByStatusAndDirection(status, direction);
            ActionResult<IEnumerable<GetMessageByStatusAndDirectionResponse>> result = new ActionResult<IEnumerable<GetMessageByStatusAndDirectionResponse>>
            {
                Result = lst.Adapt<IEnumerable<GetMessageByStatusAndDirectionResponse>>()
            };

            return result;
        }
    }
}
