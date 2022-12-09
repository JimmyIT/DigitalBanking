using IFS.DB.Application.Common.AMLtrac.SourcesOfIncome.JobTypes;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.AMLtrac.SourcesOfIncome.JobTypes.GetAll;
using IFS.DB.Application.Domain.Results;
using IFS.MLTrac.OpenAPI.ClientConfig;
using IFS.MLTrac.OpenAPI.ClientConfig.Models.JobTypes;
using Mapster;
using Newtonsoft.Json;

namespace IFS.DB.Infrastructure.External.AMLtrac.SourcesOfIncome.JobTypes.GetAll
{
    public class GetAllJobTypesService : BaseAMLtracOpenAPIService, IGetAllJobTypesService
    {
        public GetAllJobTypesService(IParameterService parameterSvc)
            : base(parameterSvc)
        {

        }

        public async Task<ActionResult<IEnumerable<GetAllJobTypesResponse>>> DoActionAsync()
        {
            ActionResult<IEnumerable<GetAllJobTypesResponse>> result = new ActionResult<IEnumerable<GetAllJobTypesResponse>>()
            {
                Result = Enumerable.Empty<GetAllJobTypesResponse>()
            };

            string apiPath = OpenApiEndpoints.Ver2.JobTypes.GetAll;

            ActionResult<IEnumerable<JobTypeBasicInfoResponse>> responseObj = await GetAsync<IEnumerable<JobTypeBasicInfoResponse>>(apiPath);

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<IEnumerable<GetAllJobTypesResponse>>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }
    }
}
