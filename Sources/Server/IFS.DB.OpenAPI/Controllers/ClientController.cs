using IFS.DB.Application.Clients.ApproveAML;
using IFS.DB.Application.Clients.CheckMissingDocument;
using IFS.DB.Application.Clients.CreateAML;
using IFS.DB.Application.Clients.CreateOnBoarding;
using IFS.DB.Application.Clients.DeleteByClientNumbber;
using IFS.DB.Application.Clients.GetAMLById;
using IFS.DB.Application.Clients.MoveAMLToDataCapture;
using IFS.DB.Application.Clients.MoveAMLToRiskReview;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.API;
using IFS.DB.Application.Domain.Attributes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
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
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.Client}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.Client}")]
    public class ClientController : BaseOpenAPIController
    {
        private readonly ICreateAMLClientHandler _CreateAMLClientHandler;
        private readonly ICreateOnBoardingClientHandler _CreateOnBoardingClientHandler;
        private readonly IGetAMLClientByIdHandler _GetAMLClientByIdHandler;
        private readonly IDeleteClientByClientNumberHandler _DeleteClientByClientNumberHandler;
        private readonly IApproveAMLClientHandler _ApproveAMLClientHandler;
        private readonly ICheckClientMissingDocumentHandler _CheckClientMissingDocumentHandler;
        private readonly IMoveAMLClientToDataCaptureHandler _MoveAMLClientToDataCaptureHandler;
        private readonly IMoveAMLClientToRiskReviewHandler _MoveAMLClientToRiskReviewHandler;

        public ClientController(IErrorMessageService errorMessageSvc, 
            ICreateAMLClientHandler createAMLClientHandler,
            ICreateOnBoardingClientHandler createOnBoardingClientHandler,
            IGetAMLClientByIdHandler getAMLClientByIdHandler,
            IDeleteClientByClientNumberHandler deleteClientByClientNumberHandler,
            IApproveAMLClientHandler approveAMLClientHandler,
            ICheckClientMissingDocumentHandler checkClientMissingDocumentHandler,
            IMoveAMLClientToDataCaptureHandler moveAMLClientToDataCaptureHandler,
            IMoveAMLClientToRiskReviewHandler moveAMLClientToRiskReviewHandler)
            : base(errorMessageSvc)
        {
            _CreateAMLClientHandler = createAMLClientHandler;
            _CreateOnBoardingClientHandler = createOnBoardingClientHandler;
            _GetAMLClientByIdHandler = getAMLClientByIdHandler;
            _DeleteClientByClientNumberHandler = deleteClientByClientNumberHandler;
            _ApproveAMLClientHandler = approveAMLClientHandler;
            _CheckClientMissingDocumentHandler = checkClientMissingDocumentHandler;
            _MoveAMLClientToDataCaptureHandler = moveAMLClientToDataCaptureHandler;
            _MoveAMLClientToRiskReviewHandler = moveAMLClientToRiskReviewHandler;
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Client.CreateAML}")]
        [APIActionInfo(APIMessageActionInfo.Client.CreateAML.Code, APIMessageActionInfo.Client.CreateAML.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Client.CreateAML.Description}", $"{APIMessageActionInfo.Client.CreateAML.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(CreateAMLClientResponse), Description = $"{APIConstant.Response.Client.CreateAML}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Client.ErrorAML}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Client.ErrorAML}")]
        public async Task<IActionResult> CreateAML(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] CreateAMLClientRequest client)
        {
            _CreateAMLClientHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<CreateAMLClientResponse> result = await _CreateAMLClientHandler.DoActionAsync(client);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Client.CreateOnBoarding}")]
        [APIActionInfo(APIMessageActionInfo.Client.CreateOnBoarding.Code, APIMessageActionInfo.Client.CreateOnBoarding.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Client.CreateOnBoarding.Description}", $"{APIMessageActionInfo.Client.CreateOnBoarding.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(CreateOnBoardingClientResponse), Description = $"{APIConstant.Response.Client.CreateOnBoarding}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Client.ErrorOnBoarding}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Client.ErrorOnBoarding}")]
        public async Task<IActionResult> CreateOnBoarding(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] CreateOnBoardingClientRequest client)
        {
            _CreateOnBoardingClientHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<CreateOnBoardingClientResponse> result = await _CreateOnBoardingClientHandler.DoActionAsync(client);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpGet]
        [Route($"{APIConstant.Route.Client.GetAMLById}")]
        [APIActionInfo(APIMessageActionInfo.Client.GetAMLById.Code, APIMessageActionInfo.Client.GetAMLById.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Client.GetAMLById.Description}", $"{APIMessageActionInfo.Client.GetAMLById.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(GetAMLClientByIdResponse), Description = $"{APIConstant.Response.Client.ReadAML}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(IList<Error>), Description = $"{APIConstant.Response.Client.ErrorAML}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Client.ErrorAML}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Client.ErrorAML}")]
        public async Task<IActionResult> GetByEmail(string id)
        {
            DigiBankResult.ActionResult<GetAMLClientByIdResponse> result = await _GetAMLClientByIdHandler.DoActionAsync(id);

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

        [HttpDelete]
        [Route($"{APIConstant.Route.Client.DeleteByClientNumber}")]
        [APIActionInfo(APIMessageActionInfo.Client.DeleteByClientNumber.Code, APIMessageActionInfo.Client.DeleteByClientNumber.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Client.DeleteByClientNumber.Description}", $"{APIMessageActionInfo.Client.DeleteByClientNumber.Description}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, typeof(NoContentResult), Description = $"{APIConstant.Response.Client.Delete}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Client.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Client.Error}")]
        public async Task<IActionResult> DeleteByClientNumber(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            string clientNumber)
        {
            _DeleteClientByClientNumberHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<bool> result = await _DeleteClientByClientNumberHandler.DoActionAsync(clientNumber);

            if (result.IsNotError)
                return await NoContent204();
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPut]
        [Route($"{APIConstant.Route.Client.ApproveAML}")]
        [APIActionInfo(APIMessageActionInfo.Client.ApproveAML.Code, APIMessageActionInfo.Client.ApproveAML.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Client.ApproveAML.Description}", $"{APIMessageActionInfo.Client.ApproveAML.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(ApproveAMLClientResponse), Description = $"{APIConstant.Response.Client.UpdateAML}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Client.ErrorAML}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Client.ErrorAML}")]
        public async Task<IActionResult> ApproveAML(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] ApproveAMLClientRequest client)
        {
            _ApproveAMLClientHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<ApproveAMLClientResponse> result = await _ApproveAMLClientHandler.DoActionAsync(client);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Client.CheckMissingDocument}")]
        [APIActionInfo(APIMessageActionInfo.Client.CheckMissingDocument.Code, APIMessageActionInfo.Client.CheckMissingDocument.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Client.CheckMissingDocument.Description}", $"{APIMessageActionInfo.Client.CheckMissingDocument.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(CheckClientMissingDocumentResponse), Description = $"{APIConstant.Response.Client.ReadAML}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Client.ErrorAML}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Client.ErrorAML}")]
        public async Task<IActionResult> CheckMissingDocument(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] CheckClientMissingDocumentRequest client)
        {
            _CheckClientMissingDocumentHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<CheckClientMissingDocumentResponse> result = await _CheckClientMissingDocumentHandler.DoActionAsync(client);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Client.MoveAMLToDataCapture}")]
        [APIActionInfo(APIMessageActionInfo.Client.MoveAMLToDataCapture.Code, APIMessageActionInfo.Client.MoveAMLToDataCapture.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Client.MoveAMLToDataCapture.Description}", $"{APIMessageActionInfo.Client.MoveAMLToDataCapture.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(MoveAMLClientToDataCaptureResponse), Description = $"{APIConstant.Response.Client.UpdateAML}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Client.ErrorAML}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Client.ErrorAML}")]
        public async Task<IActionResult> MoveAMLToDataCapture(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] MoveAMLClientToDataCaptureRequest client)
        {
            _MoveAMLClientToDataCaptureHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<MoveAMLClientToDataCaptureResponse> result = await _MoveAMLClientToDataCaptureHandler.DoActionAsync(client);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Client.MoveAMLToRiskReview}")]
        [APIActionInfo(APIMessageActionInfo.Client.MoveAMLToRiskReview.Code, APIMessageActionInfo.Client.MoveAMLToRiskReview.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Client.MoveAMLToRiskReview.Description}", $"{APIMessageActionInfo.Client.MoveAMLToRiskReview.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(MoveAMLClientToRiskReviewResponse), Description = $"{APIConstant.Response.Client.UpdateAML}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Client.ErrorAML}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Client.ErrorAML}")]
        public async Task<IActionResult> MoveAMLToRiskReview(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] MoveAMLClientToRiskReviewRequest client)
        {
            _MoveAMLClientToRiskReviewHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<MoveAMLClientToRiskReviewResponse> result = await _MoveAMLClientToRiskReviewHandler.DoActionAsync(client);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }
    }
}
