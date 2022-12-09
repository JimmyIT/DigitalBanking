using IFS.DB.Application.Common.AMLtrac.Customers;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.AMLtrac.Customers.CheckMissingDocument;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Results;
using IFS.MLTrac.OpenAPI.ClientConfig;
using IFS.MLTrac.OpenAPI.ClientConfig.Models.KYC.MissingDocumentCheck;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.External.AMLtrac.Customers.CheckMissingDocument
{
    public class CheckCustomerMissingDocumentService : BaseAMLtracOpenAPIService, ICheckCustomerMissingDocumentService
    {
        private readonly ICheckCustomerMissingDocumentValidator _Validator;

        public CheckCustomerMissingDocumentService(ICheckCustomerMissingDocumentValidator validator,
            IParameterService parameterSvc)
            : base(parameterSvc)
        {
            _Validator = validator;
        }

        public async Task<ActionResult<CheckCustomerMissingDocumentResponse>> DoActionAsync(Guid amltracRefId)
        {
            ActionResult<CheckCustomerMissingDocumentResponse> result = new ActionResult<CheckCustomerMissingDocumentResponse>()
            {
                Result = new CheckCustomerMissingDocumentResponse()
                {
                    AMLtracRefId = amltracRefId,
                    IsCompleted = false
                }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(amltracRefId.ToString());
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Create model to call AMLtrac API
            MissingDocumentCheckRequest requestModel = new MissingDocumentCheckRequest() { AmlEntityGUID = amltracRefId };

            //Call AMLtracAPI
            string apiPath = OpenApiEndpoints.Ver2.AmlEntities.PerformMissingDocumentCheck;
            ActionResult<MissingDocumentCheckResponse> responseObj = await POSTJsonAsync<MissingDocumentCheckResponse>(apiPath, JsonConvert.SerializeObject(requestModel));
            if (!responseObj.IsNotError)
            {
                result.Validation = responseObj.Validation;
                return result;
            }

            result.Result.IsCompleted = responseObj.Result.Status.ToLower() == AMLDocumentCheckConst.Complete.ToLower();

            return result;
        }
    }
}
