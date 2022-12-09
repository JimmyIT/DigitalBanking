using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Notification;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Notifcations.SendSMS
{
    public interface ISendSMSHandler : IBaseHandler
    {
        Task<ActionResult<SendSMSResponse>> DoActionAsync(SendSMSRequest sms);
    }

    public class SendSMSHandler : BaseHandler, ISendSMSHandler
    {
        private readonly ISendSMSValidator _Validator;
        private readonly ISMSService _SMSSvc;

        public SendSMSHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ISendSMSValidator validator,
            ISMSService smsSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _SMSSvc = smsSvc;
        }

        public async Task<ActionResult<SendSMSResponse>> DoActionAsync(SendSMSRequest sms)
        {
            ActionResult<SendSMSResponse> result = new ActionResult<SendSMSResponse>()
            {
                Result = new SendSMSResponse() { Success = false }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(sms);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Send SMS
            ActionResult<bool> smsResult = await _SMSSvc.SendSMSAsync(sms.PhoneNumber, sms.Message);
            if (!smsResult.IsNotError)
            {
                result.Validation = smsResult.Validation;
                return result;
            }

            result.Result.Success = smsResult.Result;

            return result;
        }
    }
}
