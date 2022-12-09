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

namespace IFS.DB.Application.AccountApplications.RegisterOnboarding
{
    public interface IRegisterOnboardingAccountApplicationHandler : IBaseHandler
    {
        Task<ActionResult<RegisterOnboardingAccountApplicationResponse>> DoActionAsync();
    }

    public class RegisterOnboardingAccountApplicationHandler : BaseHandler, IRegisterOnboardingAccountApplicationHandler
    {
        private readonly IAccountApplicationRepo _AccountApplicationRepo;
        private readonly IParameterService _ParameterSvc;
        private readonly IDateTimeProvider _DateTimeProvider;
        private readonly IStringProvider _StringProvider;

        public RegisterOnboardingAccountApplicationHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IAccountApplicationRepo accountApplicationRepo,
            IParameterService parameterSvc,
            IDateTimeProvider dateTimeProvider,
            IStringProvider stringProvider)
            : base(errorMessageSvc, headerValidator)
        {
            _AccountApplicationRepo = accountApplicationRepo;
            _ParameterSvc = parameterSvc;
            _DateTimeProvider = dateTimeProvider;
            _StringProvider = stringProvider;
        }

        public async Task<ActionResult<RegisterOnboardingAccountApplicationResponse>> DoActionAsync()
        {
            ActionResult<RegisterOnboardingAccountApplicationResponse> result = new ActionResult<RegisterOnboardingAccountApplicationResponse>()
            {
                Result = new RegisterOnboardingAccountApplicationResponse()
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Set Expiry Date
            int expiryTime = await _ParameterSvc.GetApplicationEmailLinkExpiryTimeAsync();
            DateTime expiryDate = _DateTimeProvider.Now().AddHours(expiryTime);

            //Get Account Application
            AccountApplication accAppEntity = new AccountApplication()
            {
                UniqueId = _StringProvider.NewGuid(),
                DateSubmitted = _DateTimeProvider.Now(),
                EmailAddress = _StringProvider.NewGuid().ToString(),
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

            //Set Response Model
            result.Result.ApplicationId = accAppEntity.UniqueId;
            result.Result.SessionId = accAppEntity.SessionId;

            return result;
        }
    }
}
