using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Notification;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Notifcations.SendMail
{
    public interface ISendMailHandler : IBaseHandler
    {
        Task<ActionResult<SendMailResponse>> DoActionAsync(SendMailRequest email);
    }

    public class SendMailHandler : BaseHandler, ISendMailHandler
    {
        private readonly ISendMailValidator _Validator;
        private readonly IEmailService _EmailSvc;

        public SendMailHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ISendMailValidator validator,
            IEmailService emailSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _EmailSvc = emailSvc;
        }

        public async Task<ActionResult<SendMailResponse>> DoActionAsync(SendMailRequest email)
        {
            ActionResult<SendMailResponse> result = new ActionResult<SendMailResponse>()
            {
                Result = new SendMailResponse() { Success = false }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(email);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Send Mail
            result.Result.Success = await _EmailSvc.SendMailAsync(email.Subject, email.Recipients, email.Message);

            return result;
        }
    }
}
