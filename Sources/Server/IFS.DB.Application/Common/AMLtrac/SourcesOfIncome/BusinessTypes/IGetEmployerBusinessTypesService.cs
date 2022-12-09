using IFS.DB.Application.Domain.AMLtrac.SourcesOfIncome.BusinessTypes.GetEmployerBusinessTypes;
using IFS.DB.Application.Domain.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.AMLtrac.SourcesOfIncome.BusinessTypes
{
    public interface IGetEmployerBusinessTypesService
    {
        public Task<ActionResult<IEnumerable<GetEmployerBusinessTypesResponse>>> DoActionAsync();
    }
}
