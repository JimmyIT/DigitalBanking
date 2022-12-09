using IFS.DB.Application.Common.AMLtrac.Documents;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.AMLtrac.Documents.GetRules;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Results;
using IFS.MLTrac.OpenAPI.ClientConfig;
using Mapster;
using Newtonsoft.Json;

namespace IFS.DB.Infrastructure.External.AMLtrac.Documents.GetRules
{
    public class GetDocumentRulesService : BaseAMLtracOpenAPIService, IGetDocumentRulesService
    {
        public GetDocumentRulesService(IParameterService parameterSvc)
           : base(parameterSvc)
        {
        }

        public async Task<ActionResult<GetDocumentRulesResponse>> DoActionAsync(int entityType)
        {
            ActionResult<GetDocumentRulesResponse> result = new ActionResult<GetDocumentRulesResponse>()
            {
                Result = new GetDocumentRulesResponse()
                {
                    MinimumDocumentFormula = String.Empty,
                    DocumentTypes = new(),
                    ProofCodes = new(),
                }
            };

            string apiPath = OpenApiEndpoints.Ver2.MinRequiredDocuments.GetByEntityTypeId.Replace(@"{entityTypeId}", entityType.ToString());

            ActionResult<GetDocumentRulesResponse> responseObj = await GetAsync<GetDocumentRulesResponse>(apiPath);

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<GetDocumentRulesResponse>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }
    }
}
