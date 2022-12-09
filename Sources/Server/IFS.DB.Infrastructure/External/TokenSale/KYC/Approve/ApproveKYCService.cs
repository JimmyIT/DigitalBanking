using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.TokenSale.KYC;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Domain.TokenSale.KYC.Approve;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TokensSale = TagTokenSales.OpenAPI.Client.KYC.Approve;
using TokensSaleEndpoint = TagTokenSales.OpenAPI.Client.Constants.APIConstant.EndPoint;

namespace IFS.DB.Infrastructure.External.TokenSale.KYC.Approve
{
    public class ApproveKYCService : BaseTokenSaleOpenAPIService, IApproveKYCService
    {
        private readonly IApproveKYCValidator _Validator;

        public ApproveKYCService(IApproveKYCValidator validator,
            IParameterService parameterSvc,
            IStringProvider stringProvider)
            : base(parameterSvc, stringProvider)
        {
            _Validator = validator;
        }

        public async Task<ActionResult<bool>> DoActionAsync(ApproveKYCRequest kyc)
        {
            ActionResult<bool> result = new ActionResult<bool>()
            {
                Result = false
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(kyc);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Create model to call iBankOpenAPI
            TokensSale.ApproveKYCRequest tokenSaleRequest = new TokensSale.ApproveKYCRequest()
            {
                LinkId = kyc.LinkId,
                RequestId = kyc.RequestId,
                AMLRefId = kyc.AMLRefId,
                Reference = kyc.Reference
            };

            //Call iBankOpenAPI
            string apiPath = TokensSaleEndpoint.KYC.Approve;
            ActionResult<bool> responseObj = await POSTAsync<bool>(apiPath, JsonConvert.SerializeObject(tokenSaleRequest));
            if (!responseObj.IsNotError)
            {
                result.Validation = responseObj.Validation;
                return result;
            }

            result.Result = true;

            return result;
        }
    }
}
