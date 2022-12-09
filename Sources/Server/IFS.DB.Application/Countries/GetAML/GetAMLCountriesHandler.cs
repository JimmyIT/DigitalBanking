using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.Countries;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.AMLtrac.Countries.GetAll;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Countries.GetAML
{
    public interface IGetAMLCountriesHandler : IBaseHandler
    {
        Task<ActionResult<IEnumerable<GetAMLCountriesResponse>>> DoActionAsync();
    }

    public class GetAMLCountriesHandler : BaseHandler, IGetAMLCountriesHandler
    {
        private readonly IGetAllCountriesService _GetAllCountriesSvc;

        public GetAMLCountriesHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IGetAllCountriesService getAllCountriesSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _GetAllCountriesSvc = getAllCountriesSvc;
        }

        public async Task<ActionResult<IEnumerable<GetAMLCountriesResponse>>> DoActionAsync()
        {
            ActionResult<IEnumerable<GetAMLCountriesResponse>> result = new ActionResult<IEnumerable<GetAMLCountriesResponse>>()
            {
                Result = Enumerable.Empty<GetAMLCountriesResponse>()
            };

            ActionResult<IEnumerable<GetAllCountriesResponse>> responseObj = await _GetAllCountriesSvc.DoActionAsync();

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<IEnumerable<GetAMLCountriesResponse>>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }
    }
}
