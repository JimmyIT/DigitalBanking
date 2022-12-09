using IFS.DB.Application.Domain.AMLtrac.Countries.GetAll;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.AMLtrac.Countries
{
    public interface IGetAllCountriesService
    {
        Task<ActionResult<IEnumerable<GetAllCountriesResponse>>> DoActionAsync();
    }
}
