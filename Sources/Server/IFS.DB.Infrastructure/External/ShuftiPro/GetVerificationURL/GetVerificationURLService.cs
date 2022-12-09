using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.ShuftiPro;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Results;
using Mapster;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain = IFS.DB.Application.Domain.ShuftiPro.GetVerificationURL;

namespace IFS.DB.Infrastructure.External.ShuftiPro.GetVerificationURL
{
    public class GetVerificationURLService : BaseShuftiProAPIService, IGetVerificationURLService
    {
        private readonly IGetVerificationURLValidator _Validator;

        public GetVerificationURLService(IParameterService parameterSvc,
            IGetVerificationURLValidator validator) 
            : base(parameterSvc)
        {
            _Validator = validator;
        }

        public async Task<ActionResult<Domain.GetVerificationURLResponse>> DoActionAsync(Domain.GetVerificationURLRequest model)
        {
            ActionResult<Domain.GetVerificationURLResponse> result = new ActionResult<Domain.GetVerificationURLResponse>()
            {
                Result = new Domain.GetVerificationURLResponse() { Reference = model.Reference }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(model);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            int expireTime = await _ParameterSvc.GetShuftiProAPIExpireTimeAsync();

            //Create model to call ShuftiPro
            Dictionary<string, object> requestBody = new Dictionary<string, object>();
            requestBody.Add("reference", model.Reference);
            requestBody.Add("redirect_url", model.RedirectURL);
            requestBody.Add("verification_mode", "any");
            requestBody.Add("allow_online", await _ParameterSvc.GetShuftiProAPIAllowOnlineAsync() ? "1" : "0");
            requestBody.Add("allow_offline", await _ParameterSvc.GetShuftiProAPIAllowOfflineAsync() ? "1" : "0");
            requestBody.Add("allow_na_ocr_inputs", "1");
            requestBody.Add("show_feedback_form", "0");
            requestBody.Add("ttl", expireTime);

            if (await _ParameterSvc.GetShuftiProAPIAllowFaceAsync())
            {
                Dictionary<string, string> faceObj = new Dictionary<string, string>();
                faceObj.Add("proof", string.Empty);
                requestBody.Add("face", faceObj);
            }

            if (model.DocumentType?.Count > 0)
            {
                Dictionary<string, object> documentObj = new Dictionary<string, object>();
                documentObj.Add("proof", string.Empty);
                documentObj.Add("supported_types", model.DocumentType.Where(x => !string.IsNullOrEmpty(x)).ToArray());

                requestBody.Add("document", documentObj);
            }  

            if (model.AddressType?.Count > 0)
            {
                Dictionary<string, object> addressObj = new Dictionary<string, object>();
                addressObj.Add("proof", string.Empty);
                addressObj.Add("supported_types", model.AddressType.Where(x => !string.IsNullOrEmpty(x)).ToArray());
                addressObj.Add("name", string.Empty);
                addressObj.Add("full_address", string.Empty);
                addressObj.Add("address_fuzzy_match", "1");

                requestBody.Add("address", addressObj);
            }

            //Call ShuftiPro API
            string apiPath = ShuftiProAPIURLConst.GetVerificationURL;

            ActionResult<GetVerificationURLResponse> responseObj = await POSTJsonAsync<GetVerificationURLResponse>(apiPath, requestBody);

            if (responseObj.IsNotError)
            {
                result.Result = responseObj.Result.Adapt<Domain.GetVerificationURLResponse>();
                result.Result.ExpireTime = expireTime;
            }
            else
                result.Validation = responseObj.Validation;

            return result;
        }

        private void MappingType(Domain.GetVerificationURLRequest model)
        {
            List<SupportTypeMapping> lstMapping = JsonConvert.DeserializeObject<List<SupportTypeMapping>>(EmbededResourceReader.GetResource("IFS.DB.Infrastructure.External.ShuftiPro.MappingSupportType.txt"));

            if (model.DocumentType?.Count > 0)
                for (int i = 0; i < model.DocumentType.Count; i++)
                    model.DocumentType[i] = lstMapping.FirstOrDefault(x => x.DocumentCode == model.DocumentType[i])?.SupportType;

            if (model.AddressType?.Count > 0)
                for (int i = 0; i < model.AddressType.Count; i++)
                    model.AddressType[i] = lstMapping.FirstOrDefault(x => x.DocumentCode == model.AddressType[i])?.SupportType;
        }
    }

    internal class SupportTypeMapping
    {
        public string DocumentCode { get; set; }
        public string SupportType { get; set; }
    }
}
