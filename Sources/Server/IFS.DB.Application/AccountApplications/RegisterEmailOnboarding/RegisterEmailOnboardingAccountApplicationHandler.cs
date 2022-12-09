using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Notification;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.RegisterEmailOnboarding
{
    public interface IRegisterEmailOnboardingAccountApplicationHandler : IBaseHandler
    {
        Task<ActionResult<RegisterEmailOnboardingAccountApplicationResponse>> DoActionAsync(RegisterEmailOnboardingAccountApplicationRequest email);
    }

    public class RegisterEmailOnboardingAccountApplicationHandler : BaseHandler, IRegisterEmailOnboardingAccountApplicationHandler
    {
        private readonly IRegisterEmailOnboardingAccountApplicationValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;
        private readonly IEmailService _EmailSvc;
        private readonly IParameterService _ParameterSvc;
        private readonly IDateTimeProvider _DateTimeProvider;
        private readonly IStringProvider _StringProvider;

        public RegisterEmailOnboardingAccountApplicationHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IRegisterEmailOnboardingAccountApplicationValidator validator,
            IAccountApplicationRepo accountApplicationRepo,
            IEmailService emailSvc,
            IParameterService parameterSvc,
            IDateTimeProvider dateTimeProvider,
            IStringProvider stringProvider)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
            _EmailSvc = emailSvc;
            _ParameterSvc = parameterSvc;
            _DateTimeProvider = dateTimeProvider;
            _StringProvider = stringProvider;
        }

        public async Task<ActionResult<RegisterEmailOnboardingAccountApplicationResponse>> DoActionAsync(RegisterEmailOnboardingAccountApplicationRequest email)
        {
            ActionResult<RegisterEmailOnboardingAccountApplicationResponse> result = new ActionResult<RegisterEmailOnboardingAccountApplicationResponse>()
            {
                Result = new RegisterEmailOnboardingAccountApplicationResponse()
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

            //Set Expiry Date
            int expiryTime = await _ParameterSvc.GetApplicationEmailLinkExpiryTimeAsync();
            DateTime expiryDate = _DateTimeProvider.Now().AddHours(expiryTime);

            //Get Account Application
            AccountApplication accAppEntity = await _AccountApplicationRepo.GetByEmailAsync(email.Email);

            if (accAppEntity == null)
            {
                accAppEntity = new AccountApplication()
                {
                    UniqueId = _StringProvider.NewGuid(),
                    DateSubmitted = _DateTimeProvider.Now(),
                    EmailAddress = email.Email,
                    SessionId = _StringProvider.NewGuid(),
                    Status = (int)AccountApplicationStatusEnum.FirstTimeSent,
                    ExpiryDate = expiryDate,
                    ExistingAccountHolder = false,
                    DebitCardRequired = false,
                    CreditCardRequired = false,
                    OwnershipType = string.Empty,
                    NumberofSignatories = 0,
                    AutoApproved = true, //Just for KYC Portal
                    FirstTimeKyc = true, //Just for KYC Portal
                    TransactionConfirmed = true //Just for KYC Portal
                };

                await _AccountApplicationRepo.InsertAsync(accAppEntity);
            }
            else
            {
                accAppEntity.Status = (int)AccountApplicationStatusEnum.EmailResent;
                accAppEntity.SessionId = _StringProvider.NewGuid();
                accAppEntity.ExpiryDate = expiryDate;

                await _AccountApplicationRepo.UpdateAsync(accAppEntity);
            }

            //Send Mail
            await SendMail(email.Email, accAppEntity.SessionId, expiryTime);

            //Set Response Model
            result.Result.ApplicationId = accAppEntity.UniqueId;
            result.Result.SessionId = accAppEntity.SessionId;

            return result;
        }

        private async Task<bool> SendMail(string email, Guid sessionId, int expiryTime)
        {
            bool result = false;

            string onboardingRootURL = await _ParameterSvc.GetOnboardingWebURLAsync();

            string encryptedCode = _EmailSvc.FormatUrl("SessionId", sessionId.ToString());
            string confirmURL = $"{onboardingRootURL}/indiviual-registration-email{encryptedCode}";

            string emailSubject = "New Customer Registration";
            string emailContent = SetEmailTemplate(confirmURL, expiryTime);

            result = await _EmailSvc.SendMailAsync(emailSubject, email, emailContent);

            return result;
        }

        private string SetEmailTemplate(string confirmURL, int expiryTime)
        {
            string result = string.Empty;

            IDictionary context = new Hashtable();
            context.Add("ConfirmURL", confirmURL);
            context.Add("ExpiryTime", expiryTime);
            result = _EmailSvc.GetEmailContent(context, EmailTemplateConst.RegisterOnboarding);

            return result;
        }
    }
}
