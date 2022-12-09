using IFS.DB.Application.Domain.AMLtrac.SourcesOfIncome.JobTypes.GetAll;
using IFS.DB.Application.Domain.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.AMLtrac.SourcesOfIncome.JobTypes
{
    public interface IGetAllJobTypesService
    {
        public Task<ActionResult<IEnumerable<GetAllJobTypesResponse>>> DoActionAsync();
    }
}
