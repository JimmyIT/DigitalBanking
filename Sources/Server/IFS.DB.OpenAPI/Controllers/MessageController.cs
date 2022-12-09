using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.API;
using IFS.DB.Application.Domain.Attributes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Messages.Create;
using IFS.DB.Application.Messages.GetByStatusAndDirection;
using IFS.DB.Application.Messages.UpdateStatus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

using DigiBankResult = IFS.DB.Application.Domain.Results;

namespace IFS.DB.OpenAPI.Controllers
{
    [Authorize]
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.Message}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.Message}")]
    public class MessageController : BaseOpenAPIController
    {
        private readonly IGetMessageByStatusAndDirectionHandler _GetMessageByStatusAndDirectionHandler;
        private readonly IUpdateMessageStatusHandler _UpdateMessageStatusHandler;
        private readonly ICreateMessageHandler _CreateMessageHandler;

        public MessageController(IErrorMessageService errorMessageSvc, 
            IGetMessageByStatusAndDirectionHandler getMessageByStatusAndDirectionHandler,
            IUpdateMessageStatusHandler updateMessageStatusHandler,
            ICreateMessageHandler createMessageHandler)
            : base(errorMessageSvc)
        {
            _GetMessageByStatusAndDirectionHandler = getMessageByStatusAndDirectionHandler;
            _UpdateMessageStatusHandler = updateMessageStatusHandler;
            _CreateMessageHandler = createMessageHandler;
        }

        [HttpGet]
        [Route($"{APIConstant.Route.Message.GetByStatusAndDirection}")]
        [APIActionInfo(APIMessageActionInfo.Message.GetByStatusAndDirection.Code, APIMessageActionInfo.Message.GetByStatusAndDirection.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Message.GetByStatusAndDirection.Description}", $"{APIMessageActionInfo.Message.GetByStatusAndDirection.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(IEnumerable<GetMessageByStatusAndDirectionResponse>), Description = $"{APIConstant.Response.Message.Read}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Message.Error}")]
        public async Task<IActionResult> GetByStatusAndDirection(MQMessageStatusEnum status, string direction)
        {
            DigiBankResult.ActionResult<IEnumerable<GetMessageByStatusAndDirectionResponse>> result = await _GetMessageByStatusAndDirectionHandler.DoActionAsync(status, direction);
            return await Ok200(result.Result);
        }

        [HttpPut]
        [Route($"{APIConstant.Route.Message.UpdateStatus}")]
        [APIActionInfo(APIMessageActionInfo.Message.UpdateStatus.Code, APIMessageActionInfo.Message.UpdateStatus.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Message.UpdateStatus.Description}", $"{APIMessageActionInfo.Message.UpdateStatus.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(IEnumerable<UpdateMessageStatusResponse>), Description = $"{APIConstant.Response.Message.Update}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Message.Error}")]
        public async Task<IActionResult> UpdateStatus(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] UpdateMessageStatusRequest message)
        {
            _UpdateMessageStatusHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<UpdateMessageStatusResponse> result = await _UpdateMessageStatusHandler.DoActionAsync(message);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Message.Create}")]
        [APIActionInfo(APIMessageActionInfo.Message.Create.Code, APIMessageActionInfo.Message.Create.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Message.Create.Description}", $"{APIMessageActionInfo.Message.Create.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(CreateMessageResponse), Description = $"{APIConstant.Response.Message.Create}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Message.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Message.Error}")]
        public async Task<IActionResult> Create(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] CreateMessageRequest account)
        {
            _CreateMessageHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<CreateMessageResponse> result = await _CreateMessageHandler.DoActionAsync(account);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }
    }
}
