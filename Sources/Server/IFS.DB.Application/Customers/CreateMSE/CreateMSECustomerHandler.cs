using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.Repo.Customers;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Customers.CreateMSE
{
    public interface ICreateMSECustomerHandler : IBaseHandler
    {
        Task<ActionResult<CreateMSECustomerResponse>> DoActionAsync(CreateMSECustomerRequest customer);
    }

    public class CreateMSECustomerHandler : BaseHandler, ICreateMSECustomerHandler
    {
        private readonly ICreateMSECustomerValidator _Validator;
        private readonly ICustomerRepo _CustomerRepo;
        private readonly ICountRepo _CountRepo;
        private readonly IMSEAuthorityCodeRepo _MSEAuthorityCodeRepo;
        private readonly ISiteParameterService _SiteParameterSvc;
        private readonly IParameterService _ParameterSvc;
        private readonly IStringProvider _StringProvider;
        private readonly IDateTimeProvider _DateProvider;
        private readonly IRandomHelper _RandomHelper;

        public CreateMSECustomerHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ICreateMSECustomerValidator validator,
            ICustomerRepo customerRepo,
            ICountRepo countRepo,
            IMSEAuthorityCodeRepo mseAuthorityCodeRepo,
            ISiteParameterService siteParameterSvc,
            IParameterService parameterSvc,
            IStringProvider stringProvider,
            IDateTimeProvider dateTimeProvider,
            IRandomHelper randomHelper)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _CustomerRepo = customerRepo;
            _CountRepo = countRepo;
            _MSEAuthorityCodeRepo = mseAuthorityCodeRepo;
            _SiteParameterSvc = siteParameterSvc;
            _ParameterSvc = parameterSvc;
            _StringProvider = stringProvider;
            _DateProvider = dateTimeProvider;
            _RandomHelper = randomHelper;
        }

        public async Task<ActionResult<CreateMSECustomerResponse>> DoActionAsync(CreateMSECustomerRequest customer)
        {
            ActionResult<CreateMSECustomerResponse> result = new ActionResult<CreateMSECustomerResponse>()
            {
                Result = new CreateMSECustomerResponse() { LogonID = customer.LogonID }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(customer);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Create Entity to store DB
            IBankCustomer ibankCusEntity = await MapMSECustomer(customer);

            CustomerParameter cusParamEntity = new CustomerParameter()
            {
                LogonId = customer.LogonID,
                LimitsCurrency = await _SiteParameterSvc.GetDefaultEntityLimitsCurrencyAsync(),
            };

            List<UserModel> lstUserProfile = new List<UserModel>();
            string defaultLanguage = !string.IsNullOrEmpty(customer.DefaultLanguage) ? customer.DefaultLanguage : await _ParameterSvc.GetDefaultLanguageAsync();

            foreach (MSEUser mseUser in customer.Users)
            {
                UserModel user = new UserModel()
                {
                    Profile = await MapUserProfile(mseUser, customer.ClientNumber, customer.LogonID, ibankCusEntity.Internal, defaultLanguage, customer.BulkRelease, customer.BulkPayment, customer.UploadPaymentFile),
                    Password = mseUser.Password,
                    PIN = mseUser.PIN
                };

                lstUserProfile.Add(user);
            }

            //Create MSE Customer
            IDbContextTransaction transaction = _CustomerRepo.DBContext.Database.BeginTransaction();

            try
            {
                //Create Customer
                await _CustomerRepo.CreateAsync(ibankCusEntity, cusParamEntity, lstUserProfile);

                //Allocate a new MSEAuthorityCode
                string mseAuthCode = _RandomHelper.CreateMSEAuthorityCode();
                string salt = _RandomHelper.CreateSaltValue();

                MseauthorityCode mseAuthCodeEntity = new MseauthorityCode()
                {
                    LogonId = customer.LogonID,
                    Salt = salt,
                    AuthorityCode = HashHelper.HashStringValue(mseAuthCode, salt)
                };

                await _MSEAuthorityCodeRepo.CreateAsync(mseAuthCodeEntity);

                //Set PIN
                foreach (MSEUser mseUser in customer.Users)
                    mseUser.PIN = lstUserProfile.FirstOrDefault(x => x.Profile.UserId == mseUser.UserId).PIN;

                result.Result.MSEAuthorityCode = mseAuthCode;
                result.Result.Users = customer.Users;

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

            return result;
        }

        private async Task<IBankCustomer> MapMSECustomer(CreateMSECustomerRequest customer)
        {
            string customerType = !string.IsNullOrEmpty(customer.CustomerType) ? customer.CustomerType : HostBranchCustomerConst.Customer;

            IBankCustomer result = new IBankCustomer()
            {
                ClientNumber = customer.ClientNumber,
                LogonId = customer.LogonID,
                CountryCode = customer.CountryCode,
                HostBranchCustomer = customerType,
                Internal = (customerType != HostBranchCustomerConst.Customer),
                PaymentFileCurrency = !string.IsNullOrEmpty(customer.PaymentCurrency) ? customer.PaymentCurrency : await _SiteParameterSvc.GetBaseCurrencyAsync(),
                Activated = customer.Activated,
                BulkReleaseTransactions = customer.BulkRelease,
                PaymentsInBulk = customer.BulkPayment,
                PaymentFileCollection = customer.UploadPaymentCollection,
                CanUploadPaymentFiles = customer.UploadPaymentFile,
                HasBeenUpgraded = true,
                IsTouristCard = false,
                ClientType = CustomerTypeConst.MSE
            };

            return result;
        }

        private async Task<UserProfile> MapUserProfile(MSEUser user, string clientNumber, string logonId, bool internalUser, string defaultLanguage, bool bulkRelease, bool bulkPayment, bool uploadPaymentFile)
        {
            string guID = _StringProvider.NewGuid().ToString();

            UserProfile result = new UserProfile()
            {
                ClientNumber = clientNumber,
                Status = ((int)UserProfileStatusEnum.LIVE).ToString(),
                RequestReference = await _CountRepo.GetNextReferenceAsync(CountTypeConst.CustomerRequest, clientNumber, logonId, string.Empty),
                CustomersReference = guID,
                UniqueId = guID,
                InternalId = guID,
                LogonId = logonId,
                IBankAdministrator = false,
                LastLoggedOn = null,
                SessionStarted = null,
                NumberofAuthorisationAttempts = 0,
                MessageForUser = string.Empty,
                LoginAttempts = 0,
                HasViewedSystemMsg = false,
                HasBeenUpgraded = true,
                HasAcceptedTandC = false,
                GroupId = string.Empty,
                FirstTime = string.IsNullOrEmpty(user.Password),
                Active = true,
                AccountLocked = false,
                UserId = user.UserId,
                FullName = user.FullName,
                Administrator = true,
                InternalUser = internalUser,
                PaymentsAllowed = false,
                MultiCcyPaymentsAllowed = false,
                Team = string.Empty,
                OwnTeamOnly = true,
                LanguageCultureId = defaultLanguage,
                AmendedOn = _DateProvider.Now(),
                AmendedBy = null,
                Email = user.Email,
                ForceKeywordChange = (string.IsNullOrEmpty(user.PIN) && string.IsNullOrEmpty(user.Password)),
                CanReleasePayments = bulkRelease,
                CanReleaseTransfers = bulkRelease,
                AllowTransferToNonInternetEnableAccount = false, 
                AuthorisePaymentsInBulk = bulkPayment,
                CanUploadPaymentFiles = uploadPaymentFile,
                MobilePhoneNumber = user.Phone,
                MobilePhoneNumberIdd = user.MobilePhoneNumberIDD
            };

            return result;
        }
    }
}
