using IFS.DB.Application.Common.AMLtrac.Currencies;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.AMLtrac.Currencies.GetAll;
using IFS.DB.Application.Domain.Results;
using IFS.MLTrac.OpenAPI.ClientConfig;
using IFS.MLTrac.OpenAPI.ClientConfig.Models.Currencies;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.External.AMLtrac.Currencies.GetAll
{
    public class GetAllCurrenciesService : BaseAMLtracOpenAPIService, IGetAllCurrenciesService
    {
        public GetAllCurrenciesService(IParameterService parameterSvc)
            : base(parameterSvc)
        {
        }

        public async Task<ActionResult<IEnumerable<GetAllCurrenciesResponse>>> DoActionAsync()
        {
            ActionResult<IEnumerable<GetAllCurrenciesResponse>> result = new ActionResult<IEnumerable<GetAllCurrenciesResponse>>()
            {
                Result = Enumerable.Empty<GetAllCurrenciesResponse>()
            };

            string apiPath = OpenApiEndpoints.Ver2.Currencies.GetAll;

            ActionResult<IEnumerable<CurrencyBasicInfoResponse>> responseObj = await GetAsync<IEnumerable<CurrencyBasicInfoResponse>>(apiPath);

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<IEnumerable<GetAllCurrenciesResponse>>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }
    }
}
