using IFS.DB.Application.Common.AMLtrac.SourcesOfIncome;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.AMLtrac.SourcesOfIncome.OccupationTypes.GetAll;
using IFS.DB.Application.Domain.Results;
using IFS.MLTrac.OpenAPI.ClientConfig;
using IFS.MLTrac.OpenAPI.ClientConfig.Models.OccupationTypes;
using Mapster;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace IFS.DB.Infrastructure.External.AMLtrac.SourcesOfIncome.GetAll
{
    public class GetAllOccupationTypesService : BaseAMLtracOpenAPIService, IGetAllOccupationTypesService
    {
        public GetAllOccupationTypesService(IParameterService parameterSvc)
            : base(parameterSvc)
        {

        }

        public async Task<ActionResult<IEnumerable<GetAllOccupationTypesResponse>>> DoActionAsync()
        {
            ActionResult<IEnumerable<GetAllOccupationTypesResponse>> result = new ActionResult<IEnumerable<GetAllOccupationTypesResponse>>()
            {
                Result = Enumerable.Empty<GetAllOccupationTypesResponse>()
            };

            string apiPath = OpenApiEndpoints.Ver2.OccupationTypes.GetAll;

            ActionResult<IEnumerable<OccupationTypeBasicInfoResponse>> responseObj = await GetAsync<IEnumerable<OccupationTypeBasicInfoResponse>>(apiPath);

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<IEnumerable<GetAllOccupationTypesResponse>>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }
    }
}
