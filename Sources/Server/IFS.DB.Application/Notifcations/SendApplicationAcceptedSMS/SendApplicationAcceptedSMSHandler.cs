using IFS.Common;
using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Notification;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Notifcations.SendApplicationAcceptedSMS
{
    public interface ISendApplicationAcceptedSMSHandler : IBaseHandler
    {
        Task<ActionResult<SendApplicationAcceptedSMSResponse>> DoActionAsync(SendApplicationAcceptedSMSRequest sms);
    }

    public class SendApplicationAcceptedSMSHandler : BaseHandler, ISendApplicationAcceptedSMSHandler
    {
        private readonly ISendApplicationAcceptedSMSValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;
        private readonly ISMSService _SMSSvc;
        private readonly ISiteParameterService _SiteParameterSvc;

        public SendApplicationAcceptedSMSHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ISendApplicationAcceptedSMSValidator validator,
            IAccountApplicationRepo accountApplicationRepo,
            ISMSService smsSvc,
            ISiteParameterService siteParameterSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
            _SMSSvc = smsSvc;
            _SiteParameterSvc = siteParameterSvc;
        }

        public async Task<ActionResult<SendApplicationAcceptedSMSResponse>> DoActionAsync(SendApplicationAcceptedSMSRequest sms)
        {
            ActionResult<SendApplicationAcceptedSMSResponse> result = new ActionResult<SendApplicationAcceptedSMSResponse>()
            {
                Result = new SendApplicationAcceptedSMSResponse() { Success = false }
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

            //Get ApplicationId
            AccountApplication entity = null;

            if (!string.IsNullOrEmpty(sms.ApplicationId))
                entity = await _AccountApplicationRepo.GetByIdAsync(new Guid(sms.ApplicationId));

            if (entity == null || !string.IsNullOrEmpty(sms.ClientNumber))
                entity = await _AccountApplicationRepo.GetByClientNumberAsync(sms.ClientNumber);

            //Check entity exist
            if (entity == null)
            {
                IList<Error> errors = new List<Error>();
                errors.Add(new NotExistedError("ApplicationId or ClientNumber"));

                result.Validation = new ValidationResult(errors);
                return result;
            }

            //Check customer has register
            if (entity.Status == (int)AccountApplicationStatusEnum.Proceed)
            {
                IList<Error> errors = new List<Error>();
                errors.Add(new CustomError("Cannot send sms email due to the customer having completed digital banking registration"));

                result.Validation = new ValidationResult(errors);
                return result;
            }

            ActionResult<bool> smsResult = await SendSMS(sms.PhoneNumber, entity.UniqueId.ToString());
            if (!smsResult.IsNotError)
            {
                result.Validation = smsResult.Validation;
                return result;
            }

            result.Result.Success = smsResult.Result;

            return result;
        }

        private async Task<ActionResult<bool>> SendSMS(string phoneNumber, string applicationId)
        {
            string iBankRootURL = await _SiteParameterSvc.GetIBankURLAsync();
            string confirmURL = $"{iBankRootURL}/InternetBankingRegistration.aspx?Id={applicationId}";
            string messsage = $"Thank you for your application. Please click on the link below to complete your registration: {confirmURL}";

            return await _SMSSvc.SendSMSAsync(phoneNumber, messsage);
        }
    }
}
