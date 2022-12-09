using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.API;
using IFS.DB.Application.Domain.Attributes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Transfers.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DigiBankResult = IFS.DB.Application.Domain.Results;

namespace IFS.DB.OpenAPI.Controllers
{
    [Authorize]
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.Transfer}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.Transfer}")]
    public class TransferController : BaseOpenAPIController
    {
        private readonly ICreateTransferHandler _CreateTransferHandler;

        public TransferController(IErrorMessageService errorMessageSvc, 
            ICreateTransferHandler createTransferHandler)
            : base(errorMessageSvc)
        {
            _CreateTransferHandler = createTransferHandler;
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Transfer.Create}")]
        [APIActionInfo(APIMessageActionInfo.Transfer.Create.Code, APIMessageActionInfo.Transfer.Create.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Transfer.Create.Description}", $"{APIMessageActionInfo.Transfer.Create.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(CreateTransferResponse), Description = $"{APIConstant.Response.Transfer.Create}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Transfer.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Transfer.Error}")]
        public async Task<IActionResult> Create(
            [IdempotencyKeyHeaderAttribute(Required = true)] string idempotencyKey,
            [FromBody]CreateTransferRequest transfer)
        {
            _CreateTransferHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<CreateTransferResponse> result = await _CreateTransferHandler.DoActionAsync(transfer);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }
    }
}
