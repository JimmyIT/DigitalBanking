using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Parameters.GetByKey
{
    public interface IGetParameterByKeyHandler : IBaseHandler
    {
        Task<ActionResult<GetParameterByKeyResponse>> DoActionAsync(string paramKey);
    }

    public class GetParameterByKeyHandler : BaseHandler, IGetParameterByKeyHandler
    {
        private readonly IGetParameterByKeyValidator _Validator;
        private readonly IParameterService _ParameterSvc;
        private readonly ISiteParameterService _SiteParameterSvc;

        public GetParameterByKeyHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IGetParameterByKeyValidator validator,
            IParameterService parameterSvc,
            ISiteParameterService siteParameterSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _ParameterSvc = parameterSvc;
            _SiteParameterSvc = siteParameterSvc;
        }

        public async Task<ActionResult<GetParameterByKeyResponse>> DoActionAsync(string paramKey)
        {
            ActionResult<GetParameterByKeyResponse> result = new ActionResult<GetParameterByKeyResponse>()
            {
                Result = new GetParameterByKeyResponse() { ParameKey = paramKey }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(paramKey);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Get Data
            object paramValue = paramKey switch
            {
                _ when paramKey.Equals(ParamKeyConst.AMLApprovedMode, StringComparison.OrdinalIgnoreCase) => await _ParameterSvc.GetAMLApprovedModeAsync(),
                _ when paramKey.Equals(ParamKeyConst.BankHomePage, StringComparison.OrdinalIgnoreCase) => await _SiteParameterSvc.GetBankHomePageAsync(),
                _ when paramKey.Equals(ParamKeyConst.DocumentUploadFolder, StringComparison.OrdinalIgnoreCase) => await _ParameterSvc.GetDocumentUploadFolderAsync(),
                _ when paramKey.Equals(ParamKeyConst.DocumentSizeLimit, StringComparison.OrdinalIgnoreCase) => await _ParameterSvc.GetDocumentSizeLimitAsync(),
                _ when paramKey.Equals(ParamKeyConst.InitVector, StringComparison.OrdinalIgnoreCase) => await _ParameterSvc.GetInitVectorAsync(),
                _ when paramKey.Equals(ParamKeyConst.OnboardingProduction, StringComparison.OrdinalIgnoreCase) => await _ParameterSvc.GetOnboardingProductionAsync(),
                _ when paramKey.Equals(ParamKeyConst.PasswordStrength, StringComparison.OrdinalIgnoreCase) => await _ParameterSvc.GetPasswordStrengthAsync(),
                _ when paramKey.Equals(ParamKeyConst.SendiBankCustomerRegistrationNotification, StringComparison.OrdinalIgnoreCase) => await _ParameterSvc.GetSendiBankCustomerRegistrationNotificationAsync(),
                _ => null
            };

            if (paramValue == null)
                result.Result = null;
            else
                result.Result.ParamValue = paramValue;

            return result;
        }
    }
}
