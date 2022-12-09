using IFS.DB.Application.Common.AMLtrac.Customers;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.AMLtrac.Customers.GetLinkId;
using IFS.DB.Application.Domain.Results;
using IFS.MLTrac.OpenAPI.ClientConfig;
using IFS.MLTrac.OpenAPI.ClientConfig.Models.KYC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IFS.DB.Infrastructure.External.AMLtrac.Customers.GetLinkId
{
    public class GetCustomerLinkIdService : BaseAMLtracOpenAPIService, IGetCustomerLinkIdService
    {
        private readonly IGetCustomerLinkIdValidator _Validator;

        public GetCustomerLinkIdService(IGetCustomerLinkIdValidator validator,
            IParameterService parameterSvc)
            : base(parameterSvc)
        {
            _Validator = validator;
        }

        public async Task<ActionResult<GetCustomerLinkIdResponse>> DoActionAsync(string amltracRefId)
        {
            ActionResult<GetCustomerLinkIdResponse> result = new ActionResult<GetCustomerLinkIdResponse>()
            {
                Result = new GetCustomerLinkIdResponse() { AMLtracRefId = amltracRefId }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(amltracRefId);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            // Call AMLtracAPI
            string apiPath = OpenApiEndpoints.Ver2.AmlEntities.GetLinkIdsByEntityGuid.Replace("{entityGuid}", amltracRefId);

            ActionResult<List<AmlEntityLinkIdsRetrievalResponse>> responseObj = await GetAsync<List<AmlEntityLinkIdsRetrievalResponse>>(apiPath);
            if (!responseObj.IsNotError)
            {
                result.Validation = responseObj.Validation;
                return result;
            }

            if (responseObj.Result?.Count() >= 0)
            {
                string hostId = await _ParameterSvc.GetBWHostIdAsync();

                foreach (AmlEntityLinkIdsRetrievalResponse item in responseObj.Result)
                {
                    if (item.HostSystemCode == hostId)
                    {
                        result.Result.ClientNumber = item.LinkId;
                        break;
                    }
                }
            }
            else
            {
                result.Result = null;
            }

            return result;
        }
    }
}
