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

namespace IFS.DB.Application.Countries.GetAll
{
    public interface IGetAllCountriesHandler : IBaseHandler
    {
        Task<ActionResult<IEnumerable<GetAllCountriesResponse>>> DoActionAsync();
    }

    public class GetAllCountriesHandler : BaseHandler, IGetAllCountriesHandler
    {
        private readonly ICountryRepo _CountryRepo;

        public GetAllCountriesHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            ICountryRepo countryRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _CountryRepo = countryRepo;
        }

        public async Task<ActionResult<IEnumerable<GetAllCountriesResponse>>> DoActionAsync()
        {
            //Config Mapping
            GetAllCountriesResponse.ConfigMapping();

            //Get Data
            IEnumerable<CountryCode> lst = await _CountryRepo.GetAllAsync();
            ActionResult<IEnumerable<GetAllCountriesResponse>> result  = new ActionResult<IEnumerable<GetAllCountriesResponse>>
            {
                Result = lst.Adapt<IEnumerable<GetAllCountriesResponse>>()
            };

            return result;
        }
    }
}
