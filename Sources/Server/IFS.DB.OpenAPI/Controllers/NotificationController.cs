using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.API;
using IFS.DB.Application.Domain.Attributes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Notifcations.SendApplicationAcceptedEmail;
using IFS.DB.Application.Notifcations.SendApplicationAcceptedSMS;
using IFS.DB.Application.Notifcations.SendMail;
using IFS.DB.Application.Notifcations.SendSMS;
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
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.Notification}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.Notification}")]
    public class NotificationController : BaseOpenAPIController
    {
        private readonly ISendMailHandler _SendMailHandler;
        private readonly ISendApplicationAcceptedEmailHandler _SendApplicationAcceptedEmailHandler;
        private readonly ISendSMSHandler _SendSMSHandler;
        private readonly ISendApplicationAcceptedSMSHandler _SendApplicationAcceptedSMSHandler;

        public NotificationController(IErrorMessageService errorMessageSvc, 
            ISendMailHandler sendMailHandler,
            ISendApplicationAcceptedEmailHandler sendApplicationAcceptedEmailHandler,
            ISendSMSHandler sendSMSHandler,
            ISendApplicationAcceptedSMSHandler sendApplicationAcceptedSMSHandler)
            : base(errorMessageSvc)
        {
            _SendMailHandler = sendMailHandler;
            _SendApplicationAcceptedEmailHandler = sendApplicationAcceptedEmailHandler;
            _SendSMSHandler = sendSMSHandler;
            _SendApplicationAcceptedSMSHandler = sendApplicationAcceptedSMSHandler;
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Notification.SendMail}")]
        [APIActionInfo(APIMessageActionInfo.Notification.SendMail.Code, APIMessageActionInfo.Notification.SendMail.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Notification.SendMail.Description}", $"{APIMessageActionInfo.Notification.SendMail.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(SendMailResponse), Description = $"{APIConstant.Response.Notification.MailSuccess}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Notification.MailError}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Notification.MailError}")]
        public async Task<IActionResult> SendMail(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] SendMailRequest email)
        {
            _SendMailHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<SendMailResponse> result = await _SendMailHandler.DoActionAsync(email);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Notification.SendApplicationAcceptedEmail}")]
        [APIActionInfo(APIMessageActionInfo.Notification.SendApplicationAcceptedEmail.Code, APIMessageActionInfo.Notification.SendApplicationAcceptedEmail.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Notification.SendApplicationAcceptedEmail.Description}", $"{APIMessageActionInfo.Notification.SendApplicationAcceptedEmail.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(SendApplicationAcceptedEmailResponse), Description = $"{APIConstant.Response.Notification.MailSuccess}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Notification.MailError}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Notification.MailError}")]
        public async Task<IActionResult> SendApplicationAcceptedEmail(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] SendApplicationAcceptedEmailRequest email)
        {
            _SendApplicationAcceptedEmailHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<SendApplicationAcceptedEmailResponse> result = await _SendApplicationAcceptedEmailHandler.DoActionAsync(email);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Notification.SendSMS}")]
        [APIActionInfo(APIMessageActionInfo.Notification.SendSMS.Code, APIMessageActionInfo.Notification.SendSMS.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Notification.SendSMS.Description}", $"{APIMessageActionInfo.Notification.SendSMS.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(SendSMSResponse), Description = $"{APIConstant.Response.Notification.MailSuccess}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Notification.SMSSuccess}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Notification.SMSError}")]
        public async Task<IActionResult> SendSMS(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] SendSMSRequest sms)
        {
            _SendSMSHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<SendSMSResponse> result = await _SendSMSHandler.DoActionAsync(sms);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }

        [HttpPost]
        [Route($"{APIConstant.Route.Notification.SendApplicationAcceptedSMS}")]
        [APIActionInfo(APIMessageActionInfo.Notification.SendApplicationAcceptedSMS.Code, APIMessageActionInfo.Notification.SendApplicationAcceptedSMS.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Notification.SendApplicationAcceptedSMS.Description}", $"{APIMessageActionInfo.Notification.SendApplicationAcceptedSMS.Description}")]
        [SwaggerResponse(StatusCodes.Status201Created, typeof(SendApplicationAcceptedSMSResponse), Description = $"{APIConstant.Response.Notification.SMSSuccess}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.Notification.SMSError}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Notification.SMSError}")]
        public async Task<IActionResult> SendApplicationAcceptedSMS(
            [IdempotencyKeyHeader(Required = true)] string idempotencyKey,
            [FromBody] SendApplicationAcceptedSMSRequest sms)
        {
            _SendApplicationAcceptedSMSHandler.Header = new APIHeader() { IdempotencyKey = idempotencyKey };

            DigiBankResult.ActionResult<SendApplicationAcceptedSMSResponse> result = await _SendApplicationAcceptedSMSHandler.DoActionAsync(sms);

            if (result.IsNotError)
                return await Created201(result.Result);
            else
                return await BadRequest400(result.Validation.Errors);
        }
    }
}
