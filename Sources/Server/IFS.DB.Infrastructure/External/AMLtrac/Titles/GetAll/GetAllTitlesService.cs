using IFS.DB.Application.Common.AMLtrac.Titles;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.AMLtrac.Titles.GetAll;
using IFS.DB.Application.Domain.Results;
using IFS.MLTrac.OpenAPI.ClientConfig;
using IFS.MLTrac.OpenAPI.ClientConfig.Models.KYC.IndividualTitles;
using Mapster;
using Newtonsoft.Json;
using System.Xml.Linq;


namespace IFS.DB.Infrastructure.External.AMLtrac.Titles.GetAll
{
    public class GetAllTitlesService : BaseAMLtracOpenAPIService, IGetAllTitlesService
    {
        public GetAllTitlesService(IParameterService parameterSvc) 
            : base(parameterSvc)
        {

        }

        public async Task<ActionResult<IEnumerable<GetAllTitlesResponse>>> DoActionAsync()
        {
            ActionResult<IEnumerable<GetAllTitlesResponse>> result = new ActionResult<IEnumerable<GetAllTitlesResponse>>()
            {
                Result = Enumerable.Empty<GetAllTitlesResponse>()
            };

            string apiPath = OpenApiEndpoints.Ver2.IndividualTitles.GetAll;

            ActionResult<IEnumerable<IndividualTitleResponse>> responseObj = await GetAsync<IEnumerable<IndividualTitleResponse>>(apiPath);

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<IEnumerable<GetAllTitlesResponse>>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }       
    }
}
