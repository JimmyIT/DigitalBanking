using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.API;
using IFS.DB.Application.Domain.Attributes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.SessionInformations.Create;
using IFS.DB.Application.SessionInformations.Delete;
using IFS.DB.Application.SessionInformations.GetById;
using IFS.DB.Application.SessionInformations.Reset;
using IFS.DB.Application.SessionInformations.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

using DigiBankResult = IFS.DB.Application.Domain.Results;

namespace IFS.DB.OpenAPI.Controllers
{
    [Authorize]
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.SessionInformation}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.SessionInformation}")]
    public class SessionInformationController : BaseOpenAPIController
    {
        private readonly IGetSessionInformationByIdHandler _GetSessionInformationByIdHandler;
        private readonly ICreateSessionInformationHandler _CreateSessionInformationHandler;
        private readonly IUpdateSessionInformationHandler _UpdateSessionInformationHandler;
        private readonly IResetSessionInformationHandler _ResetSessionInformationHandler;
        private readonly IDeleteSessionInformationHandler _DeleteSessionInformationHandler;

        public SessionInformationController(IErrorMessageService errorMessageSvc, 
            IGetSessionInformationByIdHandler getSessionInformationByIdHandler,
            ICreateSessionInformationHandler createSessionInformationHandler,
            IUpdateSessionInformationHandler updateSessionInformationHandler,
            IResetSessionInformationHandler resetSessionInformationHandler,
            IDeleteSessionInformationHandler deleteSessionInformationHandler)
            : base(errorMessageSvc)
        {
            _GetSessionInformationByIdHandler = getSessionInformationByIdHandler;
            _CreateSessionInformationHandler = createSessionInformationHandler;
            _UpdateSessionInformationHandler = updateSessionInformationHandler;
            _ResetSessionInformationHandler = resetSessionInformationHandler;
            _DeleteSessionInformationHandler = deleteSessionInformationHandler;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route($"{APIConstant.Route.SessionInformation.GetById}")]
        [APIActionInfo(APIMessageActionInfo.SessionInformation.GetById.Code, APIMessageActionInfo.SessionInformation.GetById.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.SessionInformation.GetById.Description}", $"{APIMessageActionInfo.SessionInformation.GetById.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(GetSessionInformationByIdResponse), Description = $"{APIConstant.Response.SessionInformation.Read}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(Error), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        public async Task<IActionResult> GetById(
            [FromRoute] string id)
        {
            DigiBankResult.ActionResult<GetSessionInformationByIdResponse> result = await _GetSessionInformationByIdHandler.DoActionAsync(id);

            if (!result.IsNotError)
                return await BadRequest400(result.Validation.Errors);

            if (result.IsNotFound)
                return await NotFound404();

            return await Ok200(result.Result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route($"{APIConstant.Route.SessionInformation.Create}")]
        [APIActionInfo(APIMessageActionInfo.SessionInformation.Create.Code, APIMessageActionInfo.SessionInformation.Create.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.SessionInformation.Create.Description}", $"{APIMessageActionInfo.SessionInformation.Create.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(NoContentResult), Description = $"{APIConstant.Response.SessionInformation.Create}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(Error), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        public async Task<IActionResult> Create(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] CreateSessionInformationRequest sessionInfo)
        {
            _CreateSessionInformationHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<bool> result = await _CreateSessionInformationHandler.DoActionAsync(sessionInfo);

            if (!result.IsNotError)
                return await BadRequest400(result.Validation.Errors);

            return await NoContent204();
        }

        [AllowAnonymous]
        [HttpPut]
        [Route($"{APIConstant.Route.SessionInformation.Update}")]
        [APIActionInfo(APIMessageActionInfo.SessionInformation.Update.Code, APIMessageActionInfo.SessionInformation.Update.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.SessionInformation.Update.Description}", $"{APIMessageActionInfo.SessionInformation.Update.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(NoContentResult), Description = $"{APIConstant.Response.SessionInformation.Update}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(Error), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        public async Task<IActionResult> Update(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromRoute] string id,
            [FromBody] UpdateSessionInformationRequest sessionInfo)
        {
            _UpdateSessionInformationHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<bool> result = await _UpdateSessionInformationHandler.DoActionAsync(id, sessionInfo);

            if (!result.IsNotError)
                return await BadRequest400(result.Validation.Errors);

            if (result.IsNotFound)
                return await NotFound404();

            return await NoContent204();
        }

        [AllowAnonymous]
        [HttpPut]
        [Route($"{APIConstant.Route.SessionInformation.Reset}")]
        [APIActionInfo(APIMessageActionInfo.SessionInformation.Reset.Code, APIMessageActionInfo.SessionInformation.Reset.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.SessionInformation.Reset.Description}", $"{APIMessageActionInfo.SessionInformation.Reset.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(NoContentResult), Description = $"{APIConstant.Response.SessionInformation.Update}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(Error), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        public async Task<IActionResult> Reset(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromRoute] string id)
        {
            _ResetSessionInformationHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<bool> result = await _ResetSessionInformationHandler.DoActionAsync(id);

            if (!result.IsNotError)
                return await BadRequest400(result.Validation.Errors);

            if (result.IsNotFound)
                return await NotFound404();

            return await NoContent204();
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route($"{APIConstant.Route.SessionInformation.Delete}")]
        [APIActionInfo(APIMessageActionInfo.SessionInformation.Delete.Code, APIMessageActionInfo.SessionInformation.Delete.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.SessionInformation.Delete.Description}", $"{APIMessageActionInfo.SessionInformation.Delete.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(NoContentResult), Description = $"{APIConstant.Response.SessionInformation.Delete}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(Error), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.SessionInformation.Error}")]
        public async Task<IActionResult> Delete(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromRoute] string id)
        {
            _DeleteSessionInformationHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<bool> result = await _DeleteSessionInformationHandler.DoActionAsync(id);

            if (!result.IsNotError)
                return await BadRequest400(result.Validation.Errors);

            if (result.IsNotFound)
                return await NotFound404();

            return await NoContent204();
        }
    }
}
