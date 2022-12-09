using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.Documents;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Common.ShuftiPro;
using IFS.DB.Application.Domain.AMLtrac.Documents.GetRules;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Domain.ShuftiPro.GetVerificationURL;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Documents.GetShuftiProVerificationURL
{
    public interface IGetShuftiProVerificationURLHandler : IBaseHandler
    {
        Task<ActionResult<GetShuftiProVerificationURLResponse>> DoActionAsync(GetShuftiProVerificationURLRequest model);
    }

    public class GetShuftiProVerificationURLHandler : BaseHandler, IGetShuftiProVerificationURLHandler
    {
        private readonly IGetShuftiProVerificationURLValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;
        private readonly IStringProvider _StringProvider;
        private readonly IDateTimeProvider _DateProvider;
        private readonly IParameterService _ParameterSvc;
        private readonly IGetVerificationURLService _GetVerificationURLSvc;

        private List<string> _LstDocumentType = null;
        private List<string> _LstAddressType = null;

        public GetShuftiProVerificationURLHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IGetShuftiProVerificationURLValidator validator,
            IAccountApplicationRepo accountApplicationRepo,
            IStringProvider stringProvider,
            IDateTimeProvider dateProvider,
            IParameterService parameterSvc,
            IGetVerificationURLService getVerificationURLSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
            _StringProvider = stringProvider;
            _DateProvider = dateProvider;
            _ParameterSvc = parameterSvc;
            _GetVerificationURLSvc = getVerificationURLSvc;
        }

        public async Task<ActionResult<GetShuftiProVerificationURLResponse>> DoActionAsync(GetShuftiProVerificationURLRequest model)
        {
            ActionResult<GetShuftiProVerificationURLResponse> result = new ActionResult<GetShuftiProVerificationURLResponse>()
            {
                Result = new GetShuftiProVerificationURLResponse() { ApplicationId = model.ApplicationId }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(model);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Get Detail Id
            AccountApplication entity = await _AccountApplicationRepo.GetByIdAsync(model.ApplicationId);

            //Check ShuftiPro Verification URL expire
            if (!string.IsNullOrEmpty(entity.ShuftiProVerificationUrl) && entity.ShuftiProUrlExpiryDate.GetValueOrDefault(_DateProvider.Now()) < _DateProvider.Now())
            {
                result.Result.VerificationURL = entity.ShuftiProVerificationUrl;
                result.Result.ExpiryDate = entity.ShuftiProUrlExpiryDate;
                return result;
            }

            //Generate Reference to call ShuftiPro
            entity.ShuftiProRefId = _StringProvider.NewGuid().ToString();

            //Create List Document to send ShuftiPro
            _LstDocumentType = new List<string>()
            {
                "id_card",
                "passport"
            };

            //Create ShuftiPro Request
            GetVerificationURLRequest shuftiProRequest = new GetVerificationURLRequest()
            {
                Reference = entity.ShuftiProRefId,
                RedirectURL = $"{await _ParameterSvc.GetOnboardingWebURLAsync()}/indiviual-registration?SessionId={entity.SessionId}",
                AddressType = _LstAddressType,
                DocumentType = _LstDocumentType
            };

            //Call ShuftiPro to get Verification URL
            ActionResult<GetVerificationURLResponse> shuftiProResult = await _GetVerificationURLSvc.DoActionAsync(shuftiProRequest);
            if (!shuftiProResult.IsNotError)
            {
                result.Validation = shuftiProResult.Validation;
                return result;
            }

            //Update ShuftiPro Info
            entity.ShuftiProVerificationUrl = shuftiProResult.Result.VerificationURL;
            entity.ShuftiProUrlExpiryDate = _DateProvider.Now().AddMinutes(shuftiProResult.Result.ExpireTime);
            await _AccountApplicationRepo.UpdateAsync(entity);

            //Return Data
            result.Result.VerificationURL = entity.ShuftiProVerificationUrl;
            result.Result.ExpiryDate = entity.ShuftiProUrlExpiryDate;

            return result;
        }

        private void MappingDocType(GetDocumentRulesResponse documentRule)
        {
            if (documentRule.MinimumDocumentFormula.Contains("B"))
            {
                _LstAddressType = documentRule.DocumentTypes.Where(x => x.ProofCode == "A" || x.ProofCode == "B").Select(x => x.DocumentCode).ToList();
                _LstDocumentType = documentRule.DocumentTypes.Where(x => x.ProofCode == "N" || x.ProofCode == "B").Select(x => x.DocumentCode).ToList();
            }
            else
            {
                if (documentRule.MinimumDocumentFormula.Contains("A"))
                    _LstAddressType = documentRule.DocumentTypes.Where(x => x.ProofCode == "A").Select(x => x.DocumentCode).ToList();

                if (documentRule.MinimumDocumentFormula.Contains("N"))
                    _LstDocumentType = documentRule.DocumentTypes.Where(x => x.ProofCode == "N").Select(x => x.DocumentCode).ToList();
            }
            
        }
    }
}
