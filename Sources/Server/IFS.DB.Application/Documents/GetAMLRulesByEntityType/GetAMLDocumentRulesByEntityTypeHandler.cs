using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.Documents;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.AMLtrac.Documents.GetRules;
using IFS.DB.Application.Domain.Results;
using Mapster;
using System;
using System.Threading.Tasks;

namespace IFS.DB.Application.Documents.GetAMLRulesByEntityType
{
    public interface IGetAMLDocumentRulesByEntityTypeHandler : IBaseHandler
    {
        public Task<ActionResult<GetAMLDocumentRulesByEntityTypeResponse>> DoActionAsync(int entityType);
    }

    public class GetAMLDocumentRulesByEntityTypeHandler : BaseHandler, IGetAMLDocumentRulesByEntityTypeHandler
    {
        private readonly IGetDocumentRulesService _GetDocumentRulesSvc;
        public GetAMLDocumentRulesByEntityTypeHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, IGetDocumentRulesService getDocumentRulesSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _GetDocumentRulesSvc = getDocumentRulesSvc;
        }

        public async Task<ActionResult<GetAMLDocumentRulesByEntityTypeResponse>> DoActionAsync(int entityType)
        {
            ActionResult<GetAMLDocumentRulesByEntityTypeResponse> result = new ActionResult<GetAMLDocumentRulesByEntityTypeResponse>()
            {
                Result = new GetAMLDocumentRulesByEntityTypeResponse()
                {
                    MinimumDocumentFormula = String.Empty,
                    ProofCodes = new(),
                    DocumentTypes = new()
                }
            };

            ActionResult<GetDocumentRulesResponse> responseObj = await _GetDocumentRulesSvc.DoActionAsync(entityType);

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<GetAMLDocumentRulesByEntityTypeResponse>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }
    }
}
