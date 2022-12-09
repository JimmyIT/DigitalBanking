using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.OpenAPI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(AsyncMessageActionFilter))]
    public class BaseOpenAPIController : ControllerBase
    {
        private IErrorMessageService _ErrorMessageSvc;

        public BaseOpenAPIController(IErrorMessageService errorMessageSvc) 
        {
            _ErrorMessageSvc = errorMessageSvc; 
        }

        protected async Task<IActionResult> Ok200(object content)
        {
            return content != null ? Ok(content) : Ok();
        }

        protected async Task<IActionResult> BadRequest400(object response)
        {
            return BadRequest(response);
        }

        protected async Task<IActionResult> Created201(object response)
        {
            return StatusCode((int)HttpStatusCode.Created, response);
        }

        protected async Task<IActionResult> NoContent204()
        {
            return NoContent();
        }

        protected async Task<IActionResult> NotFound404()
        {
            Error error = await _ErrorMessageSvc.CreateAsync(ErrorMessageCode.ResourceNotFound);

            return StatusCode((int)HttpStatusCode.NotFound, error);
        }

        protected async Task<IActionResult> NotFound404(object response)
        {
            return NotFound(response);
        }

        protected async Task<IActionResult> InternalServerError500(string additionalInfo)
        {
            Error error = await _ErrorMessageSvc.CreateInternalServerErrorAsync(additionalInfo);

            return StatusCode((int)HttpStatusCode.InternalServerError, error);
        }
    }
}
