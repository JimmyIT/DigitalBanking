using IFS.DB.Application.Domain.AMLtrac.Currencies.GetAll;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.AMLtrac.Currencies
{
    public interface IGetAllCurrenciesService
    {
        Task<ActionResult<IEnumerable<GetAllCurrenciesResponse>>> DoActionAsync();
    }
}
