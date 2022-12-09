using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;

namespace IFS.DB.Application.SessionInformations.Create
{
    public interface ICreateSessionInformationHandler : IBaseHandler
    {
        Task<ActionResult<bool>> DoActionAsync(CreateSessionInformationRequest customer);
    }

    public class CreateSessionInformationHandler : BaseHandler, ICreateSessionInformationHandler
    {
        private readonly ICreateSessionInformationValidator _Validator;
        private readonly ISessionInformationRepo _SessionInformationRepo;
        private readonly ISiteParameterService _SiteParameterSvc;
        private readonly IParameterService _ParameterSvc;
        private readonly IIPAddressProvider _IPAddressProvider;
        private readonly IDateTimeProvider _DateTimeProvider;

        public CreateSessionInformationHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ICreateSessionInformationValidator validator,
            ISessionInformationRepo sessionInformationRepo,
            ISiteParameterService siteParameterSvc,
            IParameterService parameterSvc,
            IIPAddressProvider iPAddressProvider,
            IDateTimeProvider dateTimeProvider)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _SessionInformationRepo = sessionInformationRepo;
            _SiteParameterSvc = siteParameterSvc;
            _ParameterSvc = parameterSvc;
            _IPAddressProvider = iPAddressProvider;
            _DateTimeProvider = dateTimeProvider;
        }

        public async Task<ActionResult<bool>> DoActionAsync(CreateSessionInformationRequest sessionInfo)
        {
            ActionResult<bool> result = new ActionResult<bool>()
            {
                Result = false
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(sessionInfo);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            SessionInformation entity = new SessionInformation()
            {
                SessionId = sessionInfo.SessionId,
                Ip = _IPAddressProvider.GetClientIPAddress(),
                Expiry = _DateTimeProvider.Now().AddMinutes(await _SiteParameterSvc.GetExternalCustomerTimeOutAsync()),
                LogonId = string.Empty, // dummy value as this is a required column
                ShowStatementBalances = true, // dummy value as this is a required column
                ShowMultipleNarratives = true, // dummy value as this is a required column
                StatementFrom = _DateTimeProvider.Now(),
                StatementTo = _DateTimeProvider.Now(),
                PeriodStart = _DateTimeProvider.Now(),
                PeriodEnd = _DateTimeProvider.Now(),
                SpecificDateValueFrom = _DateTimeProvider.Now(),
                SpecificDateValueTo = _DateTimeProvider.Now(),
                UsersCulture = await _ParameterSvc.GetDefaultLanguageAsync()
            };

            await _SessionInformationRepo.InsertAsync(entity);
            result.Result = true;

            return result;
        }
    }
}
