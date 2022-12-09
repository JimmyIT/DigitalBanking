using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.Currencies;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.AMLtrac.Currencies.GetAll;
using IFS.DB.Application.Domain.Results;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Currencies.GetAML
{
    public interface IGetAMLCurrenciesHandler : IBaseHandler
    {
        Task<ActionResult<IEnumerable<GetAMLCurrenciesResponse>>> DoActionAsync();
    }

    public class GetAMLCurrenciesHandler : BaseHandler, IGetAMLCurrenciesHandler
    {
        private readonly IGetAllCurrenciesService _GetAllCurrenciesSvc;

        public GetAMLCurrenciesHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IGetAllCurrenciesService getAllCurrenciesSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _GetAllCurrenciesSvc = getAllCurrenciesSvc;
        }

        public async Task<ActionResult<IEnumerable<GetAMLCurrenciesResponse>>> DoActionAsync()
        {
            ActionResult<IEnumerable<GetAMLCurrenciesResponse>> result = new ActionResult<IEnumerable<GetAMLCurrenciesResponse>>()
            {
                Result = Enumerable.Empty<GetAMLCurrenciesResponse>()
            };

            ActionResult<IEnumerable<GetAllCurrenciesResponse>> responseObj = await _GetAllCurrenciesSvc.DoActionAsync();

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<IEnumerable<GetAMLCurrenciesResponse>>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }
    }
}
