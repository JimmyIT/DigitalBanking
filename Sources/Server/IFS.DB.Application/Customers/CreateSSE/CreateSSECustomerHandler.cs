using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.Repo.Customers;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Customers.CreateSSE
{
    public interface ICreateSSECustomerHandler : IBaseHandler
    {
        Task<ActionResult<CreateSSECustomerResponse>> DoActionAsync(CreateSSECustomerRequest customer);
    }

    public class CreateSSECustomerHandler : BaseHandler, ICreateSSECustomerHandler
    {
        private readonly ICreateSSECustomerValidator _Validator;
        private readonly ICustomerRepo _CustomerRepo;
        private readonly IUserRightRepo _UserRightRepo;
        private readonly IClientRepo _ClientRepo;
        private readonly ICountRepo _CountRepo;
        private readonly ISiteParameterService _SiteParameterSvc;
        private readonly IParameterService _ParameterSvc;
        private readonly IStringProvider _StringProvider;
        private readonly IDateTimeProvider _DateProvider;

        public CreateSSECustomerHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ICreateSSECustomerValidator validator,
            ICustomerRepo customerRepo,
            IUserRightRepo userRightRepo,
            IClientRepo clientRepo,
            ICountRepo countRepo,
            ISiteParameterService siteParameterSvc,
            IParameterService parameterSvc,
            IStringProvider stringProvider,
            IDateTimeProvider dateTimeProvider)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _CustomerRepo = customerRepo;
            _UserRightRepo = userRightRepo;
            _ClientRepo = clientRepo;
            _CountRepo = countRepo;
            _SiteParameterSvc = siteParameterSvc;
            _ParameterSvc = parameterSvc;
            _StringProvider = stringProvider;
            _DateProvider = dateTimeProvider;
        }

        public async Task<ActionResult<CreateSSECustomerResponse>> DoActionAsync(CreateSSECustomerRequest customer)
        {
            ActionResult<CreateSSECustomerResponse> result = new ActionResult<CreateSSECustomerResponse>()
            {
                Result = new CreateSSECustomerResponse() { LogonID = customer.LogonID }
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
            IBankCustomer ibankCusEntity = await MapSSECustomer(customer);

            CustomerParameter cusParamEntity = new CustomerParameter()
            {
                LogonId = customer.LogonID,
                LimitsCurrency = await _SiteParameterSvc.GetDefaultEntityLimitsCurrencyAsync(),
            };

            UserModel user = new UserModel()
            {
                Profile = await MapUserProfile(customer, ibankCusEntity.Internal),
                Password = customer.Password,
                PIN = customer.PIN
            };

            List<UserModel> lstUserProfile = new List<UserModel>() { user };

            //Create SSE Customer
            IDbContextTransaction transaction = _CustomerRepo.DBContext.Database.BeginTransaction();

            try
            {
                //Create Customer
                await _CustomerRepo.CreateAsync(ibankCusEntity, cusParamEntity, lstUserProfile);

                //Create User Right
                IEnumerable<ProductCodeEnum> lstProductCode = new List<ProductCodeEnum>()
                {
                    ProductCodeEnum.AccountViewing,
                    ProductCodeEnum.Payments,
                    ProductCodeEnum.Templates,
                    ProductCodeEnum.Transfers,
                    ProductCodeEnum.BatchPayments
                };

                await _UserRightRepo.CreateListAsync(customer.ClientNumber, lstUserProfile[0].Profile.InternalId, lstProductCode);

                //Set PIN
                result.Result.PIN = lstUserProfile[0].PIN;

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

            return result;
        }

        private async Task<IBankCustomer> MapSSECustomer(CreateSSECustomerRequest customer)
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
                ClientType = CustomerTypeConst.SSE
            };

            return result;
        }

        private async Task<UserProfile> MapUserProfile(CreateSSECustomerRequest customer, bool internalUser)
        {
            Client clientEntity = await _ClientRepo.GetByClientNumberAsync(customer.ClientNumber);
            string guID = _StringProvider.NewGuid().ToString();

            UserProfile result = new UserProfile()
            {
                ClientNumber = customer.ClientNumber,
                Status = ((int)UserProfileStatusEnum.LIVE).ToString(),
                RequestReference = await _CountRepo.GetNextReferenceAsync(CountTypeConst.CustomerRequest, customer.ClientNumber, customer.LogonID, string.Empty),
                CustomersReference = guID,
                UniqueId = guID,
                InternalId = guID,
                LogonId = customer.LogonID,
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
                FirstTime = string.IsNullOrEmpty(customer.Password),
                Active = true,
                AccountLocked = false,
                UserId = customer.LogonID,
                FullName = CreateFullName(clientEntity.FirstName, clientEntity.FamilyName, clientEntity.MiddleInitial),
                Administrator = false,
                InternalUser = internalUser,
                PaymentsAllowed = true,
                MultiCcyPaymentsAllowed = true,
                Team = string.Empty,
                OwnTeamOnly = true,
                LanguageCultureId = !string.IsNullOrEmpty(customer.DefaultLanguage) ? customer.DefaultLanguage : await _ParameterSvc.GetDefaultLanguageAsync(),
                AmendedOn = _DateProvider.Now(),
                AmendedBy = null,
                Email = customer.Email,
                ForceKeywordChange = (string.IsNullOrEmpty(customer.PIN) && string.IsNullOrEmpty(customer.Password)),
                CanReleasePayments = customer.BulkRelease,
                CanReleaseTransfers = customer.BulkRelease,
                AllowTransferToNonInternetEnableAccount = true, // default for SSEs
                AuthorisePaymentsInBulk = customer.BulkPayment,
                CanUploadPaymentFiles = customer.UploadPaymentFile,
                MobilePhoneNumber = customer.Phone,
                MobilePhoneNumberIdd = customer.MobilePhoneNumberIDD
            };

            return result;
        }

        private string CreateFullName(string firstName, string lastName, string middleNameInitial)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(firstName))
            {
                result += firstName.Trim();
            }
            if (!string.IsNullOrWhiteSpace(middleNameInitial))
            {
                result += " " + middleNameInitial.Trim() + ".";
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                result += " " + lastName.Trim();
            }

            if (!string.IsNullOrEmpty(result) && result.Length > 50)
                result = result.Substring(0, 49);
            return result;
        }
    }
}
