using IFS.DB.Application.Accounts.Create;
using IFS.DB.Application.Accounts.CreateBWOnBoarding;
using IFS.DB.Application.Accounts.DeleteByAccountNumber;
using IFS.DB.Application.Accounts.UpdateBWInternetFlag;
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
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.Account}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.Account}")]
    public class AccountController : BaseOpenAPIController
    {
        private readonly ICreateBWOnBoardingAccountHandler _CreateBWOnBoardingAccountHandler;
        private readonly ICreateAccountHandler _CreateAccountHandler;
        private readonly IUpdateBWAccountInternetFlagHandler _UpdateBWAccountInternetFlagHandler;
        private readonly IDeleteAccountByAccountNumberHandler _DeleteAccountByAccountNumberHandler;

        public AccountController(IErrorMessageService errorMessageSvc, 
            ICreateBWOnBoardingAccountHandler createBWOnBoardingAccountHandler,
            ICreateAccountHandler createAccountHandler,
            IUpdateBWAccountInternetFlagHandler updateBWAccountInternetFlagHandler,
            IDeleteAccountByAccountNumberHandler deleteAccountByAccountNumberHandler)
            : base(errorMessageSvc)
        {
            _CreateBWOnBoardingAccountHandler = createBWOnBoardingAccountHandler;
            _CreateAccountHandler = createAccountHandler;
            _UpdateBWAccountInternetFlagHandler = updateBWAccountInternetFlagHandler;
            _DeleteAccountByAccountNumberHandler = deleteAccountByAccountNumberHandler;
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Account.CreateBWOnBoarding}")]
        [APIActionInfo(APIMessageActionInfo.Account.CreateBWOnBoarding.Code, APIMessageActionInfo.Account.CreateBWOnBoarding.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Account.CreateBWOnBoarding.Description}", $"{APIMessageActionInfo.Account.CreateBWOnBoarding.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(CreateBWOnBoardingAccountResponse), Description = $"{APIConstant.Response.Account.CreateBWOnBoarding}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Account.ErrorBWOnBoarding}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Account.ErrorBWOnBoarding}")]
        public async Task<IActionResult> CreateBWOnBoarding(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] CreateBWOnBoardingAccountRequest account)
        {
            _CreateBWOnBoardingAccountHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<CreateBWOnBoardingAccountResponse> result = await _CreateBWOnBoardingAccountHandler.DoActionAsync(account);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Account.Create}")]
        [APIActionInfo(APIMessageActionInfo.Account.Create.Code, APIMessageActionInfo.Account.Create.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Account.Create.Description}", $"{APIMessageActionInfo.Account.Create.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(CreateAccountResponse), Description = $"{APIConstant.Response.Account.Create}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Account.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Account.Error}")]
        public async Task<IActionResult> Create(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] CreateAccountRequest account)
        {
            _CreateAccountHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<CreateAccountResponse> result = await _CreateAccountHandler.DoActionAsync(account);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPut]
        [Route($"{APIConstant.Route.Account.UpdateBWInternetFlag}")]
        [APIActionInfo(APIMessageActionInfo.Account.UpdateBWInternetFlag.Code, APIMessageActionInfo.Account.UpdateBWInternetFlag.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Account.UpdateBWInternetFlag.Description}", $"{APIMessageActionInfo.Account.UpdateBWInternetFlag.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(UpdateBWAccountInternetFlagResponse), Description = $"{APIConstant.Response.Account.UpdateBW}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Account.ErrorBW}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Account.ErrorBW}")]
        public async Task<IActionResult> UpdateBWInternetFlag(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] UpdateBWAccountInternetFlagRequest account)
        {
            _UpdateBWAccountInternetFlagHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<UpdateBWAccountInternetFlagResponse> result = await _UpdateBWAccountInternetFlagHandler.DoActionAsync(account);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpDelete]
        [Route($"{APIConstant.Route.Account.DeleteByAccountNumber}")]
        [APIActionInfo(APIMessageActionInfo.Account.DeleteByAccountNumber.Code, APIMessageActionInfo.Account.DeleteByAccountNumber.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Account.DeleteByAccountNumber.Description}", $"{APIMessageActionInfo.Account.DeleteByAccountNumber.Description}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, typeof(NoContentResult), Description = $"{APIConstant.Response.Account.Delete}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Account.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Account.Error}")]
        public async Task<IActionResult> DeleteByAccountNumber(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            string accountNumber)
        {
            _DeleteAccountByAccountNumberHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<bool> result = await _DeleteAccountByAccountNumberHandler.DoActionAsync(accountNumber);

            if (result.IsNotError)
                return await NoContent204();
            else
                return await BadRequest400(result.Validation.Errors);
        }
    }
}
