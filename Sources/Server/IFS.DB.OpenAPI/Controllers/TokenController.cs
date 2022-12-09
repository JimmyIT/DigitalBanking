using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Attributes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.OpenAPI.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using DigiBankResult = IFS.DB.Application.Domain.Results;

namespace IFS.DB.OpenAPI.Controllers
{
    [Route($"{APIConstant.Route.Controller.Token}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.Token}")]
    public class TokenController : BaseOpenAPIController
    {
        private readonly ITokenHandler _TokenHandler;

        public TokenController(IErrorMessageService errorMessageSvc, 
            ITokenHandler tokenHandler)
            : base(errorMessageSvc)
        {
            _TokenHandler = tokenHandler;
        }

        [HttpPost]
        [APIActionInfo(APIMessageActionInfo.Token.Post.Code, APIMessageActionInfo.Token.Post.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Token.Post.Description}", $"{APIMessageActionInfo.Token.Post.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(TokenResponse), Description = $"{APIConstant.Response.Token.Create}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Token.Error}")]
        public async Task<IActionResult> Post([FromBody]TokenRequest request)
        {
            DigiBankResult.ActionResult<TokenResponse> result = await _TokenHandler.DoActionAsync(request);

            if (!result.IsNotError)
                return await BadRequest400(result.Validation.Errors);

            return await Ok200(result.Result);
        }
    }
}
