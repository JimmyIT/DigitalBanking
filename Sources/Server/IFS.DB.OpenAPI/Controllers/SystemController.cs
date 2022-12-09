using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.API;
using IFS.DB.Application.Domain.Attributes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Systems.AllowLogon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

using DigiBankResult = IFS.DB.Application.Domain.Results;

namespace IFS.DB.OpenAPI.Controllers
{
    [Authorize]
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.System}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.System}")]
    public class SystemController : BaseOpenAPIController
    {
        private readonly IAllowLogonHandler _AllowLogonHandler;

        public SystemController(IErrorMessageService errorMessageSvc,
            IAllowLogonHandler allowLogonHandler)
            : base(errorMessageSvc)
        {
            _AllowLogonHandler = allowLogonHandler;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route($"{APIConstant.Route.System.AllowLogon}")]
        [APIActionInfo(APIMessageActionInfo.System.AllowLogon.Code, APIMessageActionInfo.System.AllowLogon.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.System.AllowLogon.Description}", $"{APIMessageActionInfo.System.AllowLogon.Description}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, typeof(NoContentResult), Description = $"{APIConstant.Response.System.Read}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.System.Error}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(Error), Description = $"{APIConstant.Response.System.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.System.Error}")]
        public async Task<IActionResult> AllowLogon(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey)
        {
            _AllowLogonHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<bool> result = await _AllowLogonHandler.DoActionAsync();

            if (!result.IsNotError)
                return await BadRequest400(result.Validation.Errors);

            return await NoContent204();
        }
    }
}
