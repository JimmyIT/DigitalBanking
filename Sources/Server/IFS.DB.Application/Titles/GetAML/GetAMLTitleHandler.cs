using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.Titles;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.AMLtrac.Titles.GetAll;
using IFS.DB.Application.Domain.Results;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Titles.GetAML
{
    public interface IGetAMLTitleHandler : IBaseHandler
    {
        public Task<ActionResult<IEnumerable<GetAMLTitlesResponse>>> DoActionAsync();
    }

    public class GetAMLTitleHandler : BaseHandler, IGetAMLTitleHandler
    {
        private readonly IGetAllTitlesService _GetAllTitlesSvc;

        public GetAMLTitleHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IGetAllTitlesService getAllTitlesSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _GetAllTitlesSvc = getAllTitlesSvc;
        }

        public async Task<ActionResult<IEnumerable<GetAMLTitlesResponse>>> DoActionAsync()
        {
            ActionResult<IEnumerable<GetAMLTitlesResponse>> result = new ActionResult<IEnumerable<GetAMLTitlesResponse>>()
            {
                Result = Enumerable.Empty<GetAMLTitlesResponse>()
            };

            ActionResult<IEnumerable<GetAllTitlesResponse>> responseObj = await _GetAllTitlesSvc.DoActionAsync();

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<IEnumerable<GetAMLTitlesResponse>>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }
    }
}
