using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Documents.GetAMLRulesByEntityType;
using IFS.DB.Application.Documents.GetShuftiProVerificationStatus;
using IFS.DB.Application.Documents.GetShuftiProVerificationURL;
using IFS.DB.Application.Documents.UploadAML;
using IFS.DB.Application.Domain.API;
using IFS.DB.Application.Domain.Attributes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
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
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.Document}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.Document}")]
    public class DocumentController : BaseOpenAPIController
    {
        private readonly IGetAMLDocumentRulesByEntityTypeHandler _GetAMLDocumentRulesByEntityTypeHandler;
        private readonly IUploadAMLDocumentHandler _UploadAMLDocumentHandler;
        private readonly IGetShuftiProVerificationURLHandler _GetShuftiProVerificationURLHandler;
        private readonly IGetShuftiProVerificationStatusHandler _GetShuftiProVerificationStatusHandler;

        public DocumentController(IErrorMessageService errorMessageSvc, 
            IGetAMLDocumentRulesByEntityTypeHandler getAMLDocumentRulesByEntityTypeHandler,
            IUploadAMLDocumentHandler uploadAMLDocumentHandler,
            IGetShuftiProVerificationURLHandler getShuftiProVerificationURLHandler,
            IGetShuftiProVerificationStatusHandler getShuftiProVerificationStatusHandler)
            : base(errorMessageSvc)
        {
            _GetAMLDocumentRulesByEntityTypeHandler = getAMLDocumentRulesByEntityTypeHandler;
            _UploadAMLDocumentHandler = uploadAMLDocumentHandler;
            _GetShuftiProVerificationURLHandler = getShuftiProVerificationURLHandler;
            _GetShuftiProVerificationStatusHandler = getShuftiProVerificationStatusHandler;
        }

        [HttpGet]
        [Route($"{APIConstant.Route.Document.GetAMLRulesByEntityType}")]
        [APIActionInfo(APIMessageActionInfo.Document.GetAMLRulesByEntityType.Code, APIMessageActionInfo.Document.GetAMLRulesByEntityType.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Document.GetAMLRulesByEntityType.Description}", $"{APIMessageActionInfo.Document.GetAMLRulesByEntityType.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(GetAMLDocumentRulesByEntityTypeResponse), Description = $"{APIConstant.Response.Document.ReadAML}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Document.ErrorAML}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Document.ErrorAML}")]
        public async Task<IActionResult> GetAMLRulesByEntityType(int entityTypeId)
        {
            DigiBankResult.ActionResult<GetAMLDocumentRulesByEntityTypeResponse> result = await _GetAMLDocumentRulesByEntityTypeHandler.DoActionAsync(entityTypeId);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Document.UploadAML}")]
        [APIActionInfo(APIMessageActionInfo.Document.UploadAML.Code, APIMessageActionInfo.Document.UploadAML.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Document.UploadAML.Description}", $"{APIMessageActionInfo.Document.UploadAML.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(UploadAMLDocumentResponse), Description = $"{APIConstant.Response.Document.UploadAML}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Document.ErrorAML}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Document.ErrorAML}")]
        public async Task<IActionResult> UploadAML(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] UploadAMLDocumentRequest document)
        {
            _UploadAMLDocumentHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<UploadAMLDocumentResponse> result = await _UploadAMLDocumentHandler.DoActionAsync(document);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Document.GetShuftiProVerificationURL}")]
        [APIActionInfo(APIMessageActionInfo.Document.GetShuftiProVerificationURL.Code, APIMessageActionInfo.Document.GetShuftiProVerificationURL.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Document.GetShuftiProVerificationURL.Description}", $"{APIMessageActionInfo.Document.GetShuftiProVerificationURL.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(GetShuftiProVerificationURLResponse), Description = $"{APIConstant.Response.Document.ReadShuftiPro}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Document.ErrorShuftiPro}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Document.ErrorShuftiPro}")]
        public async Task<IActionResult> GetShuftiProVerificationURL(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] GetShuftiProVerificationURLRequest model)
        {
            _GetShuftiProVerificationURLHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<GetShuftiProVerificationURLResponse> result = await _GetShuftiProVerificationURLHandler.DoActionAsync(model);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpGet]
        [Route($"{APIConstant.Route.Document.GetShuftiProVerificationStatus}")]
        [APIActionInfo(APIMessageActionInfo.Document.GetShuftiProVerificationStatus.Code, APIMessageActionInfo.Document.GetShuftiProVerificationStatus.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Document.GetShuftiProVerificationStatus.Description}", $"{APIMessageActionInfo.Document.GetShuftiProVerificationStatus.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(GetShuftiProVerificationStatusResponse), Description = $"{APIConstant.Response.Document.ReadShuftiPro}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Document.ErrorShuftiPro}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Document.ErrorShuftiPro}")]
        public async Task<IActionResult> GetShuftiProVerificationStatus(string reference)
        {
            DigiBankResult.ActionResult<GetShuftiProVerificationStatusResponse> result = await _GetShuftiProVerificationStatusHandler.DoActionAsync(reference);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }
    }
}
