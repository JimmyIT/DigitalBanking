using IFS.DB.Application.AccountApplications.Create;
using IFS.DB.Application.AccountApplications.CreateApplicationAcceptedNotification;
using IFS.DB.Application.AccountApplications.ConfirmOnboarding;
using IFS.DB.Application.AccountApplications.DeleteById;
using IFS.DB.Application.AccountApplications.GetByEmail;
using IFS.DB.Application.AccountApplications.GetById;
using IFS.DB.Application.AccountApplications.GetBySessionId;
using IFS.DB.Application.AccountApplications.GetClearDown;
using IFS.DB.Application.AccountApplications.NotifyKYCApprove;
using IFS.DB.Application.AccountApplications.RegisterEmailOnboarding;
using IFS.DB.Application.AccountApplications.RegisterKYCOnboarding;
using IFS.DB.Application.AccountApplications.RegisterOnboarding;
using IFS.DB.Application.AccountApplications.Update;
using IFS.DB.Application.AccountApplications.UpdateKYCStatus;
using IFS.DB.Application.AccountApplications.UpdateOnboarding;
using IFS.DB.Application.AccountApplications.UpdateStatus;
using IFS.DB.Application.AccountApplications.UpdateRegisterOnboarding;
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
using IFS.DB.Application.Common.Interfaces.ErrorMessage;

namespace IFS.DB.OpenAPI.Controllers
{
    [Authorize]
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.AccountApplication}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.AccountApplication}")]
    public class AccountApplicationController : BaseOpenAPIController
    {
        private readonly IGetAccountApplicationByEmailHandler _GetAccountApplicationByEmailHandler;
        private readonly IGetAccountApplicationByIdHandler _GetAccountApplicationByIdHandler;
        private readonly IRegisterOnboardingAccountApplicationHandler _RegisterOnboardingAccountApplicationHandler;
        private readonly IUpdateAccountApplicationHandler _UpdateAccountApplicationHandler;
        private readonly IUpdateAccountApplicationStatusHandler _UpdateAccountApplicationStatusHandler;
        private readonly IUpdateAccountApplicationKYCStatusHandler _UpdateAccountApplicationKYCStatusHandler;
        private readonly ICreateAccountApplicationHandler _CreateAccountApplicationHandler;
        private readonly IUpdateOnboardingAccountApplicationHandler _UpdateOnboardingAccountApplicationHandler;
        private readonly IGetAccountApplicationBySessionIdHandler _GetAccountApplicationBySessionIdHandler;
        private readonly IUpdateRegisterOnboardingAccountApplicationHandler _UpdateRegisterOnboardingAccountApplicationHandler;
        private readonly IGetAccountApplicationClearDownHandler _GetAccountApplicationClearDownHandler;
        private readonly IDeleteAccountApplicationByIdHandler _DeleteAccountApplicationByIdHandler;
        private readonly IRegisterKYCOnboardingAccountApplicationHandler _RegisterKYCOnboardingAccountApplicationHandler;
        private readonly IRegisterEmailOnboardingAccountApplicationHandler _RegisterEmailOnboardingAccountApplicationHandler;
        private readonly ICreateAccountApplicationAcceptedNotificationHandler _CreateAccountApplicationAcceptedNotificationHandler;
        private readonly INotifyKYCApproveHandler _NotifyKYCApproveHandler;
        private readonly IConfirmOnboardingAccountApplicationHandler _ConfirmOnboardingAccountApplicationHandler;

        public AccountApplicationController(IErrorMessageService errorMessageSvc,
            IGetAccountApplicationByEmailHandler getAccountApplicationByEmailHandler,
            IGetAccountApplicationByIdHandler getAccountApplicationByIdHandler,
            IRegisterOnboardingAccountApplicationHandler registerOnboardingAccountApplicationHandler,
            IUpdateAccountApplicationHandler updateAccountApplicationHandler,
            IUpdateAccountApplicationStatusHandler updateAccountApplicationStatusHandler,
            IUpdateAccountApplicationKYCStatusHandler updateAccountApplicationKYCStatusHandler,
            ICreateAccountApplicationHandler createAccountApplicationHandler,
            IUpdateOnboardingAccountApplicationHandler updateOnboardingAccountApplicationHandler,
            IGetAccountApplicationBySessionIdHandler getAccountApplicationBySessionIdHandler,
            IUpdateRegisterOnboardingAccountApplicationHandler updateRegisterOnboardingAccountApplicationHandler,
            IGetAccountApplicationClearDownHandler getAccountApplicationClearDownHandler,
            IDeleteAccountApplicationByIdHandler deleteAccountApplicationByIdHandler,
            IRegisterKYCOnboardingAccountApplicationHandler registerKYCOnboardingAccountApplicationHandler,
            IRegisterEmailOnboardingAccountApplicationHandler registerEmailOnboardingAccountApplicationHandler,
            ICreateAccountApplicationAcceptedNotificationHandler createAccountApplicationAcceptedNotificationHandler,
            INotifyKYCApproveHandler notifyKYCApproveHandler,
            IConfirmOnboardingAccountApplicationHandler confirmOnboardingAccountApplicationHandler)
            : base(errorMessageSvc)
        {
            _GetAccountApplicationByEmailHandler = getAccountApplicationByEmailHandler;
            _GetAccountApplicationByIdHandler = getAccountApplicationByIdHandler;
            _RegisterOnboardingAccountApplicationHandler = registerOnboardingAccountApplicationHandler;
            _UpdateAccountApplicationHandler = updateAccountApplicationHandler;
            _UpdateAccountApplicationStatusHandler = updateAccountApplicationStatusHandler;
            _UpdateAccountApplicationKYCStatusHandler = updateAccountApplicationKYCStatusHandler;
            _CreateAccountApplicationHandler = createAccountApplicationHandler;
            _UpdateOnboardingAccountApplicationHandler = updateOnboardingAccountApplicationHandler;
            _GetAccountApplicationBySessionIdHandler = getAccountApplicationBySessionIdHandler;
            _UpdateRegisterOnboardingAccountApplicationHandler = updateRegisterOnboardingAccountApplicationHandler;
            _GetAccountApplicationClearDownHandler = getAccountApplicationClearDownHandler;
            _DeleteAccountApplicationByIdHandler = deleteAccountApplicationByIdHandler;
            _RegisterKYCOnboardingAccountApplicationHandler = registerKYCOnboardingAccountApplicationHandler;
            _RegisterEmailOnboardingAccountApplicationHandler = registerEmailOnboardingAccountApplicationHandler;
            _CreateAccountApplicationAcceptedNotificationHandler = createAccountApplicationAcceptedNotificationHandler;
            _NotifyKYCApproveHandler = notifyKYCApproveHandler;
            _ConfirmOnboardingAccountApplicationHandler = confirmOnboardingAccountApplicationHandler;
        }

        [HttpGet]
        [Route($"{APIConstant.Route.AccountApplication.GetByEmail}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.GetByEmail.Code, APIMessageActionInfo.AccountApplication.GetByEmail.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.GetByEmail.Description}", $"{APIMessageActionInfo.AccountApplication.GetByEmail.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(GetAccountApplicationByEmailResponse), Description = $"{APIConstant.Response.AccountApplication.Read}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            DigiBankResult.ActionResult<GetAccountApplicationByEmailResponse> result = await _GetAccountApplicationByEmailHandler.DoActionAsync(email);

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

        [HttpGet]
        [Route($"{APIConstant.Route.AccountApplication.GetById}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.GetById.Code, APIMessageActionInfo.AccountApplication.GetById.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.GetById.Description}", $"{APIMessageActionInfo.AccountApplication.GetById.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(GetAccountApplicationByIdResponse), Description = $"{APIConstant.Response.AccountApplication.Read}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        public async Task<IActionResult> GetById(string id)
        {
            DigiBankResult.ActionResult<GetAccountApplicationByIdResponse> result = await _GetAccountApplicationByIdHandler.DoActionAsync(id);

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

        [HttpPost]
        [Route($"{APIConstant.Route.AccountApplication.RegisterOnboarding}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.RegisterOnboarding.Code, APIMessageActionInfo.AccountApplication.RegisterOnboarding.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.RegisterOnboarding.Description}", $"{APIMessageActionInfo.AccountApplication.RegisterOnboarding.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(RegisterOnboardingAccountApplicationResponse), Description = $"{APIConstant.Response.AccountApplication.CreateOnboarding}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.ErrorOnboarding}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.ErrorOnboarding}")]
        public async Task<IActionResult> RegisterOnboarding(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey)
        {
            _RegisterOnboardingAccountApplicationHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<RegisterOnboardingAccountApplicationResponse> result = await _RegisterOnboardingAccountApplicationHandler.DoActionAsync();

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.AccountApplication.Create}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.Create.Code, APIMessageActionInfo.AccountApplication.Create.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.Create.Description}", $"{APIMessageActionInfo.AccountApplication.Create.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(CreateAccountApplicationResponse), Description = $"{APIConstant.Response.AccountApplication.Create}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        public async Task<IActionResult> Create(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] CreateAccountApplicationRequest accApp)
        {
            _CreateAccountApplicationHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<CreateAccountApplicationResponse> result = await _CreateAccountApplicationHandler.DoActionAsync(accApp);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPut]
        [Route($"{APIConstant.Route.AccountApplication.Update}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.Update.Code, APIMessageActionInfo.AccountApplication.Update.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.Update.Description}", $"{APIMessageActionInfo.AccountApplication.Update.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(UpdateAccountApplicationResponse), Description = $"{APIConstant.Response.AccountApplication.Update}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        public async Task<IActionResult> Update(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] UpdateAccountApplicationRequest accApp)
        {
            _UpdateAccountApplicationHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<UpdateAccountApplicationResponse> result = await _UpdateAccountApplicationHandler.DoActionAsync(accApp);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPut]
        [Route($"{APIConstant.Route.AccountApplication.UpdateStatus}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.UpdateStatus.Code, APIMessageActionInfo.AccountApplication.UpdateStatus.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.UpdateStatus.Description}", $"{APIMessageActionInfo.AccountApplication.UpdateStatus.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(UpdateAccountApplicationStatusResponse), Description = $"{APIConstant.Response.AccountApplication.Update}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        public async Task<IActionResult> UpdateStatus(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] UpdateAccountApplicationStatusRequest accApp)
        {
            _UpdateAccountApplicationStatusHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<UpdateAccountApplicationStatusResponse> result = await _UpdateAccountApplicationStatusHandler.DoActionAsync(accApp);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPut]
        [Route($"{APIConstant.Route.AccountApplication.UpdateKYCStatus}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.UpdateKYCStatus.Code, APIMessageActionInfo.AccountApplication.UpdateKYCStatus.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.UpdateKYCStatus.Description}", $"{APIMessageActionInfo.AccountApplication.UpdateKYCStatus.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(UpdateAccountApplicationStatusResponse), Description = $"{APIConstant.Response.AccountApplication.Update}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        public async Task<IActionResult> UpdateKYCStatus(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] UpdateAccountApplicationKYCStatusRequest accApp)
        {
            _UpdateAccountApplicationKYCStatusHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<UpdateAccountApplicationKYCStatusResponse> result = await _UpdateAccountApplicationKYCStatusHandler.DoActionAsync(accApp);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPut]
        [Route($"{APIConstant.Route.AccountApplication.UpdateOnboarding}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.UpdateOnboarding.Code, APIMessageActionInfo.AccountApplication.UpdateOnboarding.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.UpdateOnboarding.Description}", $"{APIMessageActionInfo.AccountApplication.UpdateOnboarding.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(UpdateOnboardingAccountApplicationResponse), Description = $"{APIConstant.Response.AccountApplication.UpdateOnboarding}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.ErrorOnboarding}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.ErrorOnboarding}")]
        public async Task<IActionResult> UpdateOnboarding(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] UpdateOnboardingAccountApplicationRequest accApp)
        {
            _UpdateOnboardingAccountApplicationHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<UpdateOnboardingAccountApplicationResponse> result = await _UpdateOnboardingAccountApplicationHandler.DoActionAsync(accApp);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpGet]
        [Route($"{APIConstant.Route.AccountApplication.GetBySessionId}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.GetBySessionId.Code, APIMessageActionInfo.AccountApplication.GetBySessionId.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.GetByEmail.Description}", $"{APIMessageActionInfo.AccountApplication.GetBySessionId.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(GetAccountApplicationBySessionIdResponse), Description = $"{APIConstant.Response.AccountApplication.Read}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        public async Task<IActionResult> GetBySessionId(Guid sessionId)
        {
            DigiBankResult.ActionResult<GetAccountApplicationBySessionIdResponse> result = await _GetAccountApplicationBySessionIdHandler.DoActionAsync(sessionId);

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

        [HttpPut]
        [Route($"{APIConstant.Route.AccountApplication.UpdateRegisterOnboarding}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.UpdateRegisterOnboarding.Code, APIMessageActionInfo.AccountApplication.UpdateRegisterOnboarding.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.UpdateRegisterOnboarding.Description}", $"{APIMessageActionInfo.AccountApplication.UpdateRegisterOnboarding.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(UpdateRegisterOnboardingAccountApplicationResponse), Description = $"{APIConstant.Response.AccountApplication.UpdateOnboarding}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.ErrorOnboarding}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.ErrorOnboarding}")]
        public async Task<IActionResult> UpdateRegisterOnboarding(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] UpdateRegisterOnboardingAccountApplicationRequest onboarding)
        {
            _UpdateRegisterOnboardingAccountApplicationHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<UpdateRegisterOnboardingAccountApplicationResponse> result = await _UpdateRegisterOnboardingAccountApplicationHandler.DoActionAsync(onboarding);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpGet]
        [Route($"{APIConstant.Route.AccountApplication.GetClearDown}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.GetClearDown.Code, APIMessageActionInfo.AccountApplication.GetClearDown.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.GetClearDown.Description}", $"{APIMessageActionInfo.AccountApplication.GetClearDown.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(IEnumerable<GetAccountApplicationClearDownResponse>), Description = $"{APIConstant.Response.AccountApplication.Read}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        public async Task<IActionResult> GetClearDown()
        {
            DigiBankResult.ActionResult<IEnumerable<GetAccountApplicationClearDownResponse>> result = await _GetAccountApplicationClearDownHandler.DoActionAsync();

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
        [Route($"{APIConstant.Route.AccountApplication.DeleteById}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.DeleteById.Code, APIMessageActionInfo.AccountApplication.DeleteById.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.DeleteById.Description}", $"{APIMessageActionInfo.AccountApplication.DeleteById.Description}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, typeof(NoContentResult), Description = $"{APIConstant.Response.AccountApplication.Delete}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        public async Task<IActionResult> DeleteById(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            Guid id)
        {
            _DeleteAccountApplicationByIdHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<bool> result = await _DeleteAccountApplicationByIdHandler.DoActionAsync(id);

            if (result.IsNotError)
                return await NoContent204();
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.AccountApplication.RegisterKYCOnboarding}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.RegisterKYCOnboarding.Code, APIMessageActionInfo.AccountApplication.RegisterKYCOnboarding.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.RegisterKYCOnboarding.Description}", $"{APIMessageActionInfo.AccountApplication.RegisterKYCOnboarding.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(RegisterKYCOnboardingAccountApplicationResponse), Description = $"{APIConstant.Response.AccountApplication.CreateOnboarding}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.ErrorOnboarding}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.ErrorOnboarding}")]
        public async Task<IActionResult> RegisterKYCOnboarding(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] RegisterKYCOnboardingAccountApplicationRequest onboarding)
        {
            _RegisterKYCOnboardingAccountApplicationHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<RegisterKYCOnboardingAccountApplicationResponse> result = await _RegisterKYCOnboardingAccountApplicationHandler.DoActionAsync(onboarding);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.AccountApplication.RegisterEmailOnboarding}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.RegisterEmailOnboarding.Code, APIMessageActionInfo.AccountApplication.RegisterEmailOnboarding.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.RegisterEmailOnboarding.Description}", $"{APIMessageActionInfo.AccountApplication.RegisterEmailOnboarding.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(RegisterEmailOnboardingAccountApplicationResponse), Description = $"{APIConstant.Response.AccountApplication.CreateOnboarding}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.ErrorOnboarding}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.ErrorOnboarding}")]
        public async Task<IActionResult> RegisterEmailOnboarding(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] RegisterEmailOnboardingAccountApplicationRequest onboarding)
        {
            _RegisterEmailOnboardingAccountApplicationHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<RegisterEmailOnboardingAccountApplicationResponse> result = await _RegisterEmailOnboardingAccountApplicationHandler.DoActionAsync(onboarding);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.AccountApplication.CreateApplicationAcceptedNotification}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.CreateApplicationAcceptedNotification.Code, APIMessageActionInfo.AccountApplication.CreateApplicationAcceptedNotification.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.CreateApplicationAcceptedNotification.Description}", $"{APIMessageActionInfo.AccountApplication.CreateApplicationAcceptedNotification.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(CreateAccountApplicationAcceptedNotificationResponse), Description = $"{APIConstant.Response.AccountApplication.Create}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        public async Task<IActionResult> CreateApplicationAcceptedNotification(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] CreateAccountApplicationAcceptedNotificationRequest accountApp)
        {
            _CreateAccountApplicationAcceptedNotificationHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<CreateAccountApplicationAcceptedNotificationResponse> result = await _CreateAccountApplicationAcceptedNotificationHandler.DoActionAsync(accountApp);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.AccountApplication.NotifyKYCApprove}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.NotifyKYCApprove.Code, APIMessageActionInfo.AccountApplication.NotifyKYCApprove.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.NotifyKYCApprove.Description}", $"{APIMessageActionInfo.AccountApplication.NotifyKYCApprove.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(NotifyKYCApproveResponse), Description = $"{APIConstant.Response.AccountApplication.UpdateOnboarding}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.ErrorOnboarding}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.ErrorOnboarding}")]
        public async Task<IActionResult> NotifyKYCApprove(
           [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
           [FromBody] NotifyKYCApproveRequest kyc)
        {
            _NotifyKYCApproveHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<NotifyKYCApproveResponse> result = await _NotifyKYCApproveHandler.DoActionAsync(kyc);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPut]
        [Route($"{APIConstant.Route.AccountApplication.ConfirmOnboarding}")]
        [APIActionInfo(APIMessageActionInfo.AccountApplication.ConfirmOnboarding.Code, APIMessageActionInfo.AccountApplication.ConfirmOnboarding.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.AccountApplication.ConfirmOnboarding.Description}", $"{APIMessageActionInfo.AccountApplication.ConfirmOnboarding.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(ConfirmOnboardingAccountApplicationResponse), Description = $"{APIConstant.Response.AccountApplication.Update}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.AccountApplication.Error}")]
        public async Task<IActionResult> ConfirmOnboarding(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] ConfirmOnboardingAccountApplicationRequest accApp)
        {
            _ConfirmOnboardingAccountApplicationHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<ConfirmOnboardingAccountApplicationResponse> result = await _ConfirmOnboardingAccountApplicationHandler.DoActionAsync(accApp);

            if (result.IsNotError)
                return await Ok200(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }
    }
}
