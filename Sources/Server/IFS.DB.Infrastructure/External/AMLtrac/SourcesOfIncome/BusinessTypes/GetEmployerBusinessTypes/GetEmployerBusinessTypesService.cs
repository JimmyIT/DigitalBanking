using IFS.DB.Application.Common.AMLtrac.SourcesOfIncome.BusinessTypes;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.AMLtrac.SourcesOfIncome.BusinessTypes.GetEmployerBusinessTypes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Results;
using IFS.MLTrac.OpenAPI.ClientConfig;
using IFS.MLTrac.OpenAPI.ClientConfig.Models.BusinessTypes;
using Mapster;
using Newtonsoft.Json;


namespace IFS.DB.Infrastructure.External.AMLtrac.SourcesOfIncome.BusinessTypes.GetEmployerBusinessTypes
{
    public class GetEmployerBusinessTypesService : BaseAMLtracOpenAPIService, IGetEmployerBusinessTypesService
    {
        public GetEmployerBusinessTypesService(IParameterService parameterSvc)
            : base(parameterSvc)
        {
        }

        public async Task<ActionResult<IEnumerable<GetEmployerBusinessTypesResponse>>> DoActionAsync()
        {
            ActionResult<IEnumerable<GetEmployerBusinessTypesResponse>> result = new ActionResult<IEnumerable<GetEmployerBusinessTypesResponse>>()
            {
                Result = Enumerable.Empty<GetEmployerBusinessTypesResponse>()
            };

            string apiPath = OpenApiEndpoints.Ver2.NatureOfBusiness.GetAll;

            ActionResult<IEnumerable<BusinessTypeBasicInfoResponse>> responseObj = await GetAsync<IEnumerable<BusinessTypeBasicInfoResponse>>(apiPath);

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<IEnumerable<GetEmployerBusinessTypesResponse>>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }
    }
}
