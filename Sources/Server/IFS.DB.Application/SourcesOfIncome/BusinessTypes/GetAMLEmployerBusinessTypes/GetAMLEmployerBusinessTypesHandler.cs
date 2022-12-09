using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.SourcesOfIncome.BusinessTypes;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.AMLtrac.SourcesOfIncome.BusinessTypes.GetEmployerBusinessTypes;
using IFS.DB.Application.Domain.Results;
using Mapster;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IFS.DB.Application.SourcesOfIncome.BusinessTypes.GetAMLEmployerBusinessTypes
{
    public interface IGetAMLEmployerBusinessTypesHandler : IBaseHandler
    {
        public Task<ActionResult<IEnumerable<GetAMLEmployerBusinessTypesResponse>>> DoActionAsync();
    }

    public class GetAMLEmployerBusinessTypesHandler : BaseHandler, IGetAMLEmployerBusinessTypesHandler
    {
        private readonly IGetEmployerBusinessTypesService _GetEmployerBusinessTypesSvc;
        public GetAMLEmployerBusinessTypesHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IGetEmployerBusinessTypesService getEmployerBusinessTypesSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _GetEmployerBusinessTypesSvc = getEmployerBusinessTypesSvc;
        }

        public async Task<ActionResult<IEnumerable<GetAMLEmployerBusinessTypesResponse>>> DoActionAsync()
        {
            ActionResult<IEnumerable<GetAMLEmployerBusinessTypesResponse>> result = new ActionResult<IEnumerable<GetAMLEmployerBusinessTypesResponse>>()
            {
                Result = Enumerable.Empty<GetAMLEmployerBusinessTypesResponse>()
            };

            ActionResult<IEnumerable<GetEmployerBusinessTypesResponse>> responseObj = await _GetEmployerBusinessTypesSvc.DoActionAsync();

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<IEnumerable<GetAMLEmployerBusinessTypesResponse>>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }
    }
}
