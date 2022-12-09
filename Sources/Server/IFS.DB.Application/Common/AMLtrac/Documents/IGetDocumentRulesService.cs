using IFS.DB.Application.Domain.AMLtrac.Documents.GetRules;
using IFS.DB.Application.Domain.Results;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.AMLtrac.Documents
{
    public interface IGetDocumentRulesService
    {
        public Task<ActionResult<GetDocumentRulesResponse>> DoActionAsync(int entityType);
    }
}
