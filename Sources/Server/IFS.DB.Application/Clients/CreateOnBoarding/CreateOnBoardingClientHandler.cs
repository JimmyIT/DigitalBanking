using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Clients.CreateOnBoarding
{
    public interface ICreateOnBoardingClientHandler : IBaseHandler
    {
        Task<ActionResult<CreateOnBoardingClientResponse>> DoActionAsync(CreateOnBoardingClientRequest client);
    }

    public class CreateOnBoardingClientHandler : BaseHandler, ICreateOnBoardingClientHandler
    {
        private readonly ICreateOnBoardingClientValidator _Validator;
        private readonly IClientRepo _ClientRepo;
        private readonly IDateTimeProvider _DateTimeProvider;

        public CreateOnBoardingClientHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ICreateOnBoardingClientValidator validator,
            IClientRepo clientRepo,
            IDateTimeProvider dateTimeProvider)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _ClientRepo = clientRepo;
            _DateTimeProvider = dateTimeProvider;
        }

        public async Task<ActionResult<CreateOnBoardingClientResponse>> DoActionAsync(CreateOnBoardingClientRequest client)
        {
            ActionResult<CreateOnBoardingClientResponse> result = new ActionResult<CreateOnBoardingClientResponse>()
            {
                Result = new CreateOnBoardingClientResponse() { ClientNumber = client.ClientNumber }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(client);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Mapping Model to Entity
            string clientName = GetAlternativeStatement(client.PersonalInfo);

            Client clientEntity = new Client()
            {
                AccountManagerId = null,
                ClientName = clientName.Length > 60 ? clientName.Substring(0, 60) : clientName,
                ClientNumber = client.ClientNumber,
                ClientTown = client.City,
                ClientType = EnumHelper.GetDesc(client.ClientType),
                CountryCode = client.Country,
                Customer = true,
                EmailAddress = client.EmailAddress,
                ExternalReference = string.Empty,
                FamilyName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(client.PersonalInfo.LastName.ToLower()),
                FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(client.PersonalInfo.FirstName.ToLower()),
                GroupHeader = false,
                GroupName = string.Format("{0} {1}", client.PersonalInfo.FirstName, client.PersonalInfo.LastName),
                GroupNumber = client.ClientNumber,
                HomeAddress = string.Empty,
                HomeAddressCountry = string.Empty,
                HomeAddressLine1 = string.Empty,
                HomeAddressLine2 = string.Empty,
                Internal = false,
                Introducer = false,
                IntroducerId = string.Empty,
                Merchant = false,
                MiddleInitial = !string.IsNullOrEmpty(client.PersonalInfo.MiddleName) ? client.PersonalInfo.MiddleName.Substring(0, 1).ToUpper() : string.Empty,
                MiddleName = !string.IsNullOrEmpty(client.PersonalInfo.MiddleName) ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(client.PersonalInfo.MiddleName.ToLower()) : string.Empty,
                Mneumonic = client.ClientNumber,
                MobilePhoneNumber = client.PersonalInfo.MobilePhone,
                MobilePhoneOperator = string.Empty,
                NetworkOperator = false,
                Pincode = string.Empty,
                Registered = false,
                RegistrationType = string.Empty,
                Retailer = false,
                ScccardNo = string.Empty,
                Sccexpiry = string.Empty,
                SeeNameOnIncomingMsg = false,
                ShowNameToReceiver = false,
                SignUpDate = _DateTimeProvider.Now(),
                Title = string.Empty,
                TopUpConfirmDirectory = string.Empty,
                TopUpRequestDirectory = string.Empty,
                TopUpResponseDirectory = string.Empty,
                WelcomeSent = false
            };

            await _ClientRepo.InsertAsync(clientEntity);

            return result;
        }

        private string GetAlternativeStatement(PersonalInformation personalInfo)
        {
            string result = string.Format("{0}, {1}", personalInfo.LastName.ToLower(), personalInfo.FirstName.ToLower());

            if (!string.IsNullOrEmpty(personalInfo.MiddleName))
            {
                result += string.Format(" {0}.", personalInfo.MiddleName.Substring(0, 1).ToUpper());
            }

            return result;
        }
    }
}
