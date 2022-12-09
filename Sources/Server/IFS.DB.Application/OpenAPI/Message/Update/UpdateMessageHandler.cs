using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.API;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.OpenAPI.Message.Update
{
    public interface IUpdateMessageHandler : IBaseHandler
    {
        Task<ActionResult<bool>> DoAction(APIMessage apiMessage);
    }

    public class UpdateMessageHandler : BaseHandler, IUpdateMessageHandler
    {
        private readonly IOpenAPIRepo _OpenAPIRepo;

        public UpdateMessageHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IOpenAPIRepo openAPIRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _OpenAPIRepo = openAPIRepo;
        }

        public async Task<ActionResult<bool>> DoAction(APIMessage apiMessage)
        {
            ActionResult<bool> result = new ActionResult<bool>();
            OpenApiMessage openAPIMessage = apiMessage.Adapt<OpenApiMessage>();
            await _OpenAPIRepo.UpdateMessageAsync(openAPIMessage);
            result.Result = true;

            return result; 
        }
    }
}
