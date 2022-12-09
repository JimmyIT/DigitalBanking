using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Attributes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Parameters.GetByKey;
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
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.Parameter}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.Parameter}")]
    public class ParameterController : BaseOpenAPIController
    {
        private readonly IGetParameterByKeyHandler _GetParameterByKeyHandler;

        public ParameterController(IErrorMessageService errorMessageSvc, 
            IGetParameterByKeyHandler getParameterByKeyHandler)
            : base(errorMessageSvc)
        {
            _GetParameterByKeyHandler = getParameterByKeyHandler;
        }

        [HttpGet]
        [Route($"{APIConstant.Route.Parameter.GetByKey}")]
        [APIActionInfo(APIMessageActionInfo.Parameter.GetByKey.Code, APIMessageActionInfo.Parameter.GetByKey.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Parameter.GetByKey.Description}", $"{APIMessageActionInfo.Parameter.GetByKey.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(GetParameterByKeyResponse), Description = $"{APIConstant.Response.Parameter.Read}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(IList<Error>), Description = $"{APIConstant.Response.Parameter.Error}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Parameter.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Parameter.Error}")]
        public async Task<IActionResult> GetByEmail(string paramKey)
        {
            DigiBankResult.ActionResult<GetParameterByKeyResponse> result = await _GetParameterByKeyHandler.DoActionAsync(paramKey);

            if (result.IsNotError)
            {
                if (result.Result != null)
                    return await Ok200(result.Result);
                else
                    return await NotFound404();
            }
            else
                return await BadRequest400(result.Validation.Errors);
        }
    }
}
