using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Customers.CheckTwoFACode;
using IFS.DB.Application.Customers.CreateMSE;
using IFS.DB.Application.Customers.CreateSSE;
using IFS.DB.Application.Customers.GetById;
using IFS.DB.Application.Customers.IdentifySSE;
using IFS.DB.Application.Customers.SignInSSE;
using IFS.DB.Application.Customers.UpdateSSE;
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
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.Customer}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.Customer}")]
    public class CustomerController : BaseOpenAPIController
    {
        private readonly ICreateSSECustomerHandler _CreateSSECustomerHandler;
        private readonly IUpdateSSECustomerHandler _UpdateSSECustomerHandler;
        private readonly ICreateMSECustomerHandler _CreateMSECustomerHandler;
        private readonly IGetCustomerByIdHandler _GetCustomerByIdHandler;
        private readonly IIdentifySSECustomerHandler _IdentifySSECustomerHandler;
        private readonly ISignInSSECustomerHandler _SignInSSECustomerHandler;
        private readonly ICheckTwoFACodeCustomerHandler _CheckTwoFACodeCustomerHandler;

        public CustomerController(IErrorMessageService errorMessageSvc, 
            ICreateSSECustomerHandler createSSECustomerHandler,
            IUpdateSSECustomerHandler updateSSECustomerHandler,
            ICreateMSECustomerHandler createMSECustomerHandler,
            IGetCustomerByIdHandler getCustomerByIdHandler,
            IIdentifySSECustomerHandler identifySSECustomerHandler,
            ISignInSSECustomerHandler signInSSECustomerHandler,
            ICheckTwoFACodeCustomerHandler checkTwoFACodeCustomerHandler)
            : base(errorMessageSvc)
        {
            _CreateSSECustomerHandler = createSSECustomerHandler;
            _UpdateSSECustomerHandler = updateSSECustomerHandler;
            _CreateMSECustomerHandler = createMSECustomerHandler;
            _GetCustomerByIdHandler = getCustomerByIdHandler;
            _IdentifySSECustomerHandler = identifySSECustomerHandler;
            _SignInSSECustomerHandler = signInSSECustomerHandler;
            _CheckTwoFACodeCustomerHandler = checkTwoFACodeCustomerHandler;
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Customer.CreateSSE}")]
        [APIActionInfo(APIMessageActionInfo.Customer.CreateSSE.Code, APIMessageActionInfo.Customer.CreateSSE.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Customer.CreateSSE.Description}", $"{APIMessageActionInfo.Customer.CreateSSE.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(CreateSSECustomerResponse), Description = $"{APIConstant.Response.Customer.Create}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Customer.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Customer.Error}")]
        public async Task<IActionResult> CreateSSE(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] CreateSSECustomerRequest customer)
        {
            _CreateSSECustomerHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<CreateSSECustomerResponse> result = await _CreateSSECustomerHandler.DoActionAsync(customer);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPut]
        [Route($"{APIConstant.Route.Customer.UpdateSSE}")]
        [APIActionInfo(APIMessageActionInfo.Customer.UpdateSSE.Code, APIMessageActionInfo.Customer.UpdateSSE.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Customer.UpdateSSE.Description}", $"{APIMessageActionInfo.Customer.UpdateSSE.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(UpdateSSECustomerResponse), Description = $"{APIConstant.Response.Customer.Update}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Customer.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Customer.Error}")]
        public async Task<IActionResult> UpdateSSE(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] UpdateSSECustomerRequest customer)
        {
            _UpdateSSECustomerHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<UpdateSSECustomerResponse> result = await _UpdateSSECustomerHandler.DoActionAsync(customer);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Customer.CreateMSE}")]
        [APIActionInfo(APIMessageActionInfo.Customer.CreateMSE.Code, APIMessageActionInfo.Customer.CreateMSE.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Customer.CreateMSE.Description}", $"{APIMessageActionInfo.Customer.CreateMSE.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(CreateMSECustomerResponse), Description = $"{APIConstant.Response.Customer.Create}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Customer.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Customer.Error}")]
        public async Task<IActionResult> CreateMSE(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] CreateMSECustomerRequest customer)
        {
            _CreateMSECustomerHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<CreateMSECustomerResponse> result = await _CreateMSECustomerHandler.DoActionAsync(customer);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route($"{APIConstant.Route.Customer.GetById}")]
        [APIActionInfo(APIMessageActionInfo.Customer.GetById.Code, APIMessageActionInfo.Customer.GetById.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Customer.GetById.Description}", $"{APIMessageActionInfo.Customer.GetById.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(GetCustomerByIdResponse), Description = $"{APIConstant.Response.Customer.Read}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Customer.Error}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(Error), Description = $"{APIConstant.Response.Customer.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Customer.Error}")]
        public async Task<IActionResult> GetById(
            [FromRoute] string id)
        {
            DigiBankResult.ActionResult<GetCustomerByIdResponse> result = await _GetCustomerByIdHandler.DoActionAsync(id);

            if (!result.IsNotError)
            {
                if (result.IsNotFound)
                    return await NotFound404(result.Validation.Errors);

                return await BadRequest400(result.Validation.Errors);
            }

            return await Ok200(result.Result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route($"{APIConstant.Route.Customer.IdentifySSE}")]
        [APIActionInfo(APIMessageActionInfo.Customer.IdentifySSE.Code, APIMessageActionInfo.Customer.IdentifySSE.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Customer.IdentifySSE.Description}", $"{APIMessageActionInfo.Customer.IdentifySSE.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(IdentifySSECustomerResponse), Description = $"{APIConstant.Response.Customer.Read}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Customer.Error}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(Error), Description = $"{APIConstant.Response.Customer.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Customer.Error}")]
        public async Task<IActionResult> IdentifySSE(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] IdentifySSECustomerRequest customer)
        {
            _IdentifySSECustomerHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<IdentifySSECustomerResponse> result = await _IdentifySSECustomerHandler.DoActionAsync(customer);

            if (!result.IsNotError)
            {
                if (result.IsNotFound)
                    return await NotFound404(result.Validation.Errors);

                return await BadRequest400(result.Validation.Errors);
            }

            return await Ok200(result.Result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route($"{APIConstant.Route.Customer.SignInSSE}")]
        [APIActionInfo(APIMessageActionInfo.Customer.SignInSSE.Code, APIMessageActionInfo.Customer.SignInSSE.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Customer.SignInSSE.Description}", $"{APIMessageActionInfo.Customer.SignInSSE.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(SignInSSECustomerResponse), Description = $"{APIConstant.Response.Customer.Read}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Customer.Error}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(Error), Description = $"{APIConstant.Response.Customer.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Customer.Error}")]
        public async Task<IActionResult> SignInSSE(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] SignInSSECustomerRequest customer)
        {
            _SignInSSECustomerHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<SignInSSECustomerResponse> result = await _SignInSSECustomerHandler.DoActionAsync(customer);

            if (!result.IsNotError)
            {
                if (result.IsNotFound)
                    return await NotFound404(result.Validation.Errors);

                return await BadRequest400(result.Validation.Errors);
            }

            return await Ok200(result.Result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route($"{APIConstant.Route.Customer.CheckTwoFACode}")]
        [APIActionInfo(APIMessageActionInfo.Customer.CheckTwoFACode.Code, APIMessageActionInfo.Customer.CheckTwoFACode.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Customer.CheckTwoFACode.Description}", $"{APIMessageActionInfo.Customer.CheckTwoFACode.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(CheckTwoFACodeCustomerResponse), Description = $"{APIConstant.Response.Customer.Read}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Customer.Error}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(Error), Description = $"{APIConstant.Response.Customer.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Customer.Error}")]
        public async Task<IActionResult> CheckTwoFACode(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] CheckTwoFACodeCustomerRequest customer)
        {
            _CheckTwoFACodeCustomerHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<CheckTwoFACodeCustomerResponse> result = await _CheckTwoFACodeCustomerHandler.DoActionAsync(customer);

            if (!result.IsNotError)
            {
                if (result.IsNotFound)
                    return await NotFound404(result.Validation.Errors);

                return await BadRequest400(result.Validation.Errors);
            }

            return await Ok200(result.Result);
        }
    }
}
