using IFS.DB.Application.Common.AMLtrac.Countries;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.AMLtrac.Countries.GetAll;
using IFS.DB.Application.Domain.Results;
using IFS.MLTrac.OpenAPI.ClientConfig;
using IFS.MLTrac.OpenAPI.ClientConfig.Models.Countries;
using Mapster;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace IFS.DB.Infrastructure.External.AMLtrac.Countries.GetAll
{
    public class GetAllCountriesService : BaseAMLtracOpenAPIService, IGetAllCountriesService
    {
        public GetAllCountriesService(IParameterService parameterSvc) : base(parameterSvc)
        {
        }

        public async Task<ActionResult<IEnumerable<GetAllCountriesResponse>>> DoActionAsync()
        {
            ActionResult<IEnumerable<GetAllCountriesResponse>> result = new ActionResult<IEnumerable<GetAllCountriesResponse>>()
            {
                Result = Enumerable.Empty<GetAllCountriesResponse>()
            };

            string apiPath = OpenApiEndpoints.Ver2.Countries.GetAll;

            ActionResult<IEnumerable<CountryBasicInfoResponse>> responseObj = await GetAsync<IEnumerable<CountryBasicInfoResponse>>(apiPath);

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<IEnumerable<GetAllCountriesResponse>>();
            else
                result.Validation = responseObj.Validation;
      
            return result;
        }
    }
}
