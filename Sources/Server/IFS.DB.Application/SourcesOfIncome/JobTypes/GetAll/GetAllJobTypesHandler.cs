using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.SourcesOfIncome.JobTypes;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Results;
using Mapster;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IFS.DB.Application.SourcesOfIncome.JobTypes.GetAll
{
    public interface IGetAllJobTypesHandler : IBaseHandler
    {
        public Task<ActionResult<IEnumerable<GetAllJobTypesResponse>>> DoActionAsync();
    }

    public class GetAllJobTypesHandler : BaseHandler, IGetAllJobTypesHandler
    {
        private readonly IGetAllJobTypesService _GetAllJobTypesSvc;
        public GetAllJobTypesHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IGetAllJobTypesService getAllJobTypesSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _GetAllJobTypesSvc = getAllJobTypesSvc;
        }

        public async Task<ActionResult<IEnumerable<GetAllJobTypesResponse>>> DoActionAsync()
        {
            ActionResult<IEnumerable<GetAllJobTypesResponse>> result = new ActionResult<IEnumerable<GetAllJobTypesResponse>>()
            {
                Result = Enumerable.Empty<GetAllJobTypesResponse>()
            };

            ActionResult<IEnumerable<Domain.AMLtrac.SourcesOfIncome.JobTypes.GetAll.GetAllJobTypesResponse>> responseObj = await _GetAllJobTypesSvc.DoActionAsync();

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<IEnumerable<GetAllJobTypesResponse>>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }
    }
}
