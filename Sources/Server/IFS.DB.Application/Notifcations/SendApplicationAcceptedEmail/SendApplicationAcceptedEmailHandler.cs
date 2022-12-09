using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Notification;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Notifcations.SendApplicationAcceptedEmail
{
    public interface ISendApplicationAcceptedEmailHandler : IBaseHandler
    {
        Task<ActionResult<SendApplicationAcceptedEmailResponse>> DoActionAsync(SendApplicationAcceptedEmailRequest email);
    }

    public class SendApplicationAcceptedEmailHandler : BaseHandler, ISendApplicationAcceptedEmailHandler
    {
        private readonly ISendApplicationAcceptedEmailValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;
        private readonly IEmailService _EmailSvc;
        private readonly ISiteParameterService _SiteParameterSvc;

        public SendApplicationAcceptedEmailHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ISendApplicationAcceptedEmailValidator validator,
            IAccountApplicationRepo accountApplicationRepo,
            IEmailService emailSvc,
            ISiteParameterService siteParameterSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
            _EmailSvc = emailSvc;
            _SiteParameterSvc = siteParameterSvc;
        }

        public async Task<ActionResult<SendApplicationAcceptedEmailResponse>> DoActionAsync(SendApplicationAcceptedEmailRequest email)
        {
            ActionResult<SendApplicationAcceptedEmailResponse> result = new ActionResult<SendApplicationAcceptedEmailResponse>()
            {
                Result = new SendApplicationAcceptedEmailResponse() { Success = false }
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

            //Get ApplicationId
            AccountApplication entity = null;

            if (!string.IsNullOrEmpty(email.ApplicationId))
                entity = await _AccountApplicationRepo.GetByIdAsync(new Guid(email.ApplicationId));

            if (entity == null || !string.IsNullOrEmpty(email.ClientNumber))
                entity = await _AccountApplicationRepo.GetByClientNumberAsync(email.ClientNumber);

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
                errors.Add(new CustomError("Cannot send registration email due to the customer having completed digital banking registration"));

                result.Validation = new ValidationResult(errors);
                return result;
            }

            //Send Mail
            result.Result.Success = await SendMail(email.Email, entity.UniqueId.ToString());

            return result;
        }

        private async Task<bool> SendMail(string email, string applicationId)
        {
            bool result = false;

            string iBankRootURL = await _SiteParameterSvc.GetIBankURLAsync();

            string encryptedCode = _EmailSvc.FormatUrl("Id", applicationId);
            string confirmURL = $"{iBankRootURL}/InternetBankingRegistration.aspx{encryptedCode}";

            string emailSubject = "Application Accepted";
            string emailContent = SetEmailTemplate(confirmURL);

            result = await _EmailSvc.SendMailAsync(emailSubject, email, emailContent);

            return result;
        }

        private string SetEmailTemplate(string confirmURL)
        {
            string result = string.Empty;

            IDictionary context = new Hashtable();
            context.Add("ConfirmURL", confirmURL);
            result = _EmailSvc.GetEmailContent(context, EmailTemplateConst.ApplicationAccepted);

            return result;
        }
    }
}
