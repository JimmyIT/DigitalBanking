using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Attributes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Titles.GetAML;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

using DigiBankResult = IFS.DB.Application.Domain.Results;

namespace IFS.DB.OpenAPI.Controllers
{
    //[Authorize]
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.Title}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.Title}")]
    public class TitleController : BaseOpenAPIController
    {
        private readonly IGetAMLTitleHandler _GetAMLTitleHandler;

        public TitleController(IErrorMessageService errorMessageSvc, 
            IGetAMLTitleHandler getAMLTitleHandler)
            : base(errorMessageSvc)
        {
            _GetAMLTitleHandler = getAMLTitleHandler;
        }

        [HttpGet]
        [Route($"{APIConstant.Route.Title.GetAML}")]
        [APIActionInfo(APIMessageActionInfo.Title.GetAML.Code, APIMessageActionInfo.Title.GetAML.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Title.GetAML.Description}", $"{APIMessageActionInfo.Title.GetAML.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(IEnumerable<GetAMLTitlesResponse>), Description = $"{APIConstant.Response.Title.ReadAML}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Title.ErrorAML}")]
        public async Task<IActionResult> GetAMLTitles()
        {
            DigiBankResult.ActionResult<IEnumerable<GetAMLTitlesResponse>> result = await _GetAMLTitleHandler.DoActionAsync();
            return await Ok200(result.Result);
        }
    }
}
