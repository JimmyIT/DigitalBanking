using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Currencies.GetAll
{
    public interface IGetAllCurrenciesHandler : IBaseHandler
    {
        Task<ActionResult<IEnumerable<GetAllCurrenciesResponse>>> DoActionAsync();
    }

    public class GetAllCurrenciesHandler : BaseHandler, IGetAllCurrenciesHandler
    {
        private readonly ICurrencyRepo _CurrencyRepo;

        public GetAllCurrenciesHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            ICurrencyRepo currencyRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _CurrencyRepo = currencyRepo;
        }

        public async Task<ActionResult<IEnumerable<GetAllCurrenciesResponse>>> DoActionAsync()
        {
            IEnumerable<Currency> lst = await _CurrencyRepo.GetAllAsync();
            ActionResult<IEnumerable<GetAllCurrenciesResponse>> result = new ActionResult<IEnumerable<GetAllCurrenciesResponse>>
            {
                Result = lst.Adapt<IEnumerable<GetAllCurrenciesResponse>>()
            };

            return result;
        }
    }
}
