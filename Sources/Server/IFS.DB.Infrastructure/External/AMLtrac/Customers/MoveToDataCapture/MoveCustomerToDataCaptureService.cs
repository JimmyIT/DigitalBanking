using IFS.DB.Application.Common.AMLtrac.Customers;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.Results;
using IFS.MLTrac.OpenAPI.ClientConfig;
using IFS.MLTrac.OpenAPI.ClientConfig.Models.KYC.AmlEntities.SendEntityToDataCapture;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.External.AMLtrac.Customers.MoveToDataCapture
{
    public class MoveCustomerToDataCaptureService : BaseAMLtracOpenAPIService, IMoveCustomerToDataCaptureService
    {
        public MoveCustomerToDataCaptureService(IParameterService parameterSvc)
            : base(parameterSvc)
        {
        }

        public async Task<ActionResult<bool>> DoActionAsync(Guid entityGuid)
        {
            ActionResult<bool> result = new ActionResult<bool>()
            {
                Result = false
            };

            //Call AMLtracAPI
            string apiPath = OpenApiEndpoints.Ver2.AmlEntities.SendEntityToDataCapture.Replace("{entityGuid}", entityGuid.ToString());
            ActionResult<SendEntityToDataCaptureResult> responseObj = await POSTJsonAsync<SendEntityToDataCaptureResult>(apiPath, string.Empty);
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
