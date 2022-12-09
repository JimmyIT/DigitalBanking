using IFS.DB.Application.Domain.AMLtrac.SourcesOfIncome.OccupationTypes.GetAll;
using IFS.DB.Application.Domain.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.AMLtrac.SourcesOfIncome
{
    public interface IGetAllOccupationTypesService
    {
        public Task<ActionResult<IEnumerable<GetAllOccupationTypesResponse>>> DoActionAsync();
    }
}
