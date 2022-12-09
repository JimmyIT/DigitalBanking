using IFS.DB.Application.Common.AMLtrac.Customers;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.Results;
using IFS.MLTrac.OpenAPI.ClientConfig;
using IFS.MLTrac.OpenAPI.ClientConfig.Models.KYC.EntityApproval;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.External.AMLtrac.Customers.Approve
{
    public class ApproveCustomerService : BaseAMLtracOpenAPIService, IApproveCustomerService
    {
        private readonly IApproveCustomerValidator _Validator;

        public ApproveCustomerService(IApproveCustomerValidator validator,
            IParameterService parameterSvc)
            : base(parameterSvc)
        {
            _Validator = validator;
        }

        public async Task<ActionResult<string>> DoActionAsync(Guid applicationId)
        {
            ActionResult<string> result = new ActionResult<string>()
            {
                Result = string.Empty
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(applicationId.ToString());
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Create model to call AMLtrac API
            string hostId = await _ParameterSvc.GetAMLtracHostIdAsync();

            EntityApprovalRequest requestModel = new EntityApprovalRequest()
            {
                HostSystems = new HostSystemsData()
                {
                    LinkId = applicationId.ToString(),
                    HostSystemCode = hostId
                }
            };

            //Call AMLtracAPI
            string apiPath = OpenApiEndpoints.Ver2.AmlEntities.ApproveAnEntity;
            ActionResult<EntityApprovalResult> responseObj = await POSTJsonAsync<EntityApprovalResult>(apiPath, JsonConvert.SerializeObject(requestModel));
            if (!responseObj.IsNotError)
            {
                result.Validation = responseObj.Validation;
                return result;
            }

            return result;
        }
    }
}
