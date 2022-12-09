using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.RegisterKYCOnboarding
{
    public interface IRegisterKYCOnboardingAccountApplicationHandler : IBaseHandler
    {
        Task<ActionResult<RegisterKYCOnboardingAccountApplicationResponse>> DoActionAsync(RegisterKYCOnboardingAccountApplicationRequest kycOnboarding);
    }

    public class RegisterKYCOnboardingAccountApplicationHandler : BaseHandler, IRegisterKYCOnboardingAccountApplicationHandler
    {
        private readonly IRegisterKYCOnboardingAccountApplicationValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;
        private readonly IParameterService _ParameterSvc;
        private readonly IDateTimeProvider _DateTimeProvider;
        private readonly IStringProvider _StringProvider;

        public RegisterKYCOnboardingAccountApplicationHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IRegisterKYCOnboardingAccountApplicationValidator validator,
            IAccountApplicationRepo accountApplicationRepo,
            IParameterService parameterSvc,
            IDateTimeProvider dateTimeProvider,
            IStringProvider stringProvider)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
            _ParameterSvc = parameterSvc;
            _DateTimeProvider = dateTimeProvider;
            _StringProvider = stringProvider;
        }

        public async Task<ActionResult<RegisterKYCOnboardingAccountApplicationResponse>> DoActionAsync(RegisterKYCOnboardingAccountApplicationRequest onboarding)
        {
            ActionResult<RegisterKYCOnboardingAccountApplicationResponse> result = new ActionResult<RegisterKYCOnboardingAccountApplicationResponse>()
            {
                Result = new RegisterKYCOnboardingAccountApplicationResponse() { LinkId = onboarding.LinkId }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(onboarding);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Set Expiry Date
            int expiryTime = await _ParameterSvc.GetApplicationEmailLinkExpiryTimeAsync();
            DateTime expiryDate = _DateTimeProvider.Now().AddHours(expiryTime);

            Guid uniqueId = _StringProvider.NewGuid();

            //Get Account Application
            AccountApplication accAppEntity = await _AccountApplicationRepo.GetByEmailAsync(onboarding.Email);

            if (accAppEntity == null)
            {
                //Set Onboarding Model
                OnboardingModel onboardingModel = new OnboardingModel()
                {
                    Id = uniqueId,
                    PersonalInfo = new PersonalInformation()
                    {
                        Title = onboarding.Title,
                        FirstName = onboarding.FirstName,
                        LastName = onboarding.LastName
                    },
                    Communication = new Communication()
                    {
                        Email = onboarding.Email
                    }
                };

                accAppEntity = new AccountApplication()
                {
                    UniqueId = uniqueId,
                    DateSubmitted = _DateTimeProvider.Now(),
                    EmailAddress = onboarding.Email,
                    SessionId = _StringProvider.NewGuid(),
                    Status = (int)AccountApplicationStatusEnum.FirstTimeSent,
                    ExpiryDate = expiryDate,
                    ExistingAccountHolder = false,
                    DebitCardRequired = false,
                    CreditCardRequired = false,
                    OwnershipType = string.Empty,
                    NumberofSignatories = 0,
                    BackCallBackUrl = onboarding.BackCallBackURL,
                    SubmitCallBackUrl = onboarding.SubmitCallBackURL,
                    KycRefId = onboarding.LinkId,
                    AdditionalDocumentRequirement = onboarding.AddDocReqs,
                    FirstTimeKyc = true,
                    AutoApproved = onboarding.AutoApproved,
                    TokenPurchaseRequestId = onboarding.RequestId,
                    TokenCompanyCode = onboarding.CompanyCode,
                    TransactionConfirmed = false, //need investor confirm
                    MessageContent = JsonConvert.SerializeObject(onboardingModel)
                };

                await _AccountApplicationRepo.InsertAsync(accAppEntity);
            }
            else
            {
                accAppEntity.Status = (int)AccountApplicationStatusEnum.EmailResent;
                accAppEntity.ExpiryDate = expiryDate;
                accAppEntity.BackCallBackUrl = onboarding.BackCallBackURL;
                accAppEntity.SubmitCallBackUrl = onboarding.SubmitCallBackURL;
                accAppEntity.KycRefId = onboarding.LinkId;
                accAppEntity.AdditionalDocumentRequirement = onboarding.AddDocReqs;
                accAppEntity.TokenPurchaseRequestId = onboarding.RequestId;
                accAppEntity.AutoApproved = onboarding.AutoApproved;
                accAppEntity.TransactionConfirmed = false; //need investor confirm

                //Check if change Document Requirement, jump to step 6 //Upload Document
                if (!string.IsNullOrEmpty(accAppEntity.AmltracRefId))
                {
                    accAppEntity.Status = (int)AccountApplicationStatusEnum.ExtendRequiredDocuments;
                    accAppEntity.LatestStep = 6;
                    accAppEntity.FirstTimeKyc = false;
                }

                await _AccountApplicationRepo.UpdateAsync(accAppEntity);
            }

            //Set Response Model
            result.Result.ApplicationId = accAppEntity.UniqueId;
            result.Result.SessionId = accAppEntity.SessionId;
            result.Result.RegisterURL = $"{await _ParameterSvc.GetOnboardingWebURLAsync()}/kyc-indiviual-registration?SessionId={accAppEntity.SessionId}";

            return result;
        }
    }
}
