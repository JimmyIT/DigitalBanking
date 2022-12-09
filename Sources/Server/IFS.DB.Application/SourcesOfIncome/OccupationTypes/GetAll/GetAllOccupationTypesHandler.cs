using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.SourcesOfIncome;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Results;
using Mapster;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IFS.DB.Application.SourcesOfIncome.OccupationTypes.GetAll
{
    public interface IGetAllOccupationTypesHandler : IBaseHandler
    {
        public Task<ActionResult<IEnumerable<GetAllOccupationTypesResponse>>> DoActionAsync();
    }

    public class GetAllOccupationTypesHandler : BaseHandler, IGetAllOccupationTypesHandler
    {
        private readonly IGetAllOccupationTypesService _GetAllOccupationTypesSvc;
        public GetAllOccupationTypesHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IGetAllOccupationTypesService getAllOccupationTypesSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _GetAllOccupationTypesSvc = getAllOccupationTypesSvc;
        }

        public async Task<ActionResult<IEnumerable<GetAllOccupationTypesResponse>>> DoActionAsync()
        {
            ActionResult<IEnumerable<GetAllOccupationTypesResponse>> result = new ActionResult<IEnumerable<GetAllOccupationTypesResponse>>()
            {
                Result = Enumerable.Empty<GetAllOccupationTypesResponse>()
            };

            ActionResult<IEnumerable<Domain.AMLtrac.SourcesOfIncome.OccupationTypes.GetAll.GetAllOccupationTypesResponse>> responseObj = await _GetAllOccupationTypesSvc.DoActionAsync();

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<IEnumerable<GetAllOccupationTypesResponse>>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }
    }
}
