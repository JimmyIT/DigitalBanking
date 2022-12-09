using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.GetClearDown
{
    public interface IGetAccountApplicationClearDownHandler : IBaseHandler
    {
        Task<ActionResult<IEnumerable<GetAccountApplicationClearDownResponse>>> DoActionAsync();
    }

    public class GetAccountApplicationClearDownHandler : BaseHandler, IGetAccountApplicationClearDownHandler
    {
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public GetAccountApplicationClearDownHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public async Task<ActionResult<IEnumerable<GetAccountApplicationClearDownResponse>>> DoActionAsync()
        {
            ActionResult<IEnumerable<GetAccountApplicationClearDownResponse>> result = new ActionResult<IEnumerable<GetAccountApplicationClearDownResponse>>()
            {
                Result = Enumerable.Empty<GetAccountApplicationClearDownResponse>()
            };

            //Config Mapping
            GetAccountApplicationClearDownResponse.ConfigMapping();

            //Get Data
            IEnumerable<AccountApplication> lst = await _AccountApplicationRepo.GetClearDownAsync();
            result.Result = lst.Adapt<IEnumerable<GetAccountApplicationClearDownResponse>>();

            return result;
        }
    }
}
