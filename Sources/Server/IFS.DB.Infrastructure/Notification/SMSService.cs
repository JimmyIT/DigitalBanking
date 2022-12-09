using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.Notification;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace IFS.DB.Infrastructure.Notification
{
    public class SMSService : ISMSService
    {
        private readonly IParameterService _ParameterSvc;

        public SMSService(IParameterService parameterSvc)
        {
            _ParameterSvc = parameterSvc;
        }

        public async Task<ActionResult<bool>> SendSMSAsync(string phoneNumber, string message)
        {
            ActionResult<bool> result = new ActionResult<bool>()
            {
                Result = false
            };

            string sid = await _ParameterSvc.GetTwilioSidAsync();
            string token = await _ParameterSvc.GetTwilioTokenAsync();
            string from = await _ParameterSvc.GetTwilioFromAsync();

            if (string.IsNullOrEmpty(sid) || string.IsNullOrEmpty(token) || string.IsNullOrEmpty(from))
            {
                IList<Error> errors = new List<Error>();
                errors.Add(new MissingSettingError("Twilio"));
                result.Validation = new ValidationResult(errors);
                return result;
            }

            //Validate Phone Number need contain IDD
            if (!phoneNumber.Contains("+"))
            {
                IList<Error> errors = new List<Error>();
                errors.Add(new CustomError("Phone number must have phone number IDD"));
                result.Validation = new ValidationResult(errors);
                return result;
            }

            TwilioClient.Init(sid, token);
            try
            {
                MessageResource smsResult = MessageResource.Create(
                to: new PhoneNumber(phoneNumber),
                from: new PhoneNumber(from),
                body: message);

                result.Result = string.IsNullOrEmpty(smsResult.ErrorMessage);
            }
            catch (Exception ex)
            {
                IList<Error> errors = new List<Error>();
                errors.Add(new CustomError(ex.Message));
                result.Validation = new ValidationResult(errors);
                return result;
            }

            return result;
        }
    }
}
