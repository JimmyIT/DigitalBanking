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

namespace IFS.DB.Application.SessionInformations.GetById
{
    public interface IGetSessionInformationByIdHandler : IBaseHandler
    {
        Task<ActionResult<GetSessionInformationByIdResponse>> DoActionAsync(string id);
    }

    public class GetSessionInformationByIdHandler : BaseHandler, IGetSessionInformationByIdHandler
    {
        private readonly ISessionInformationRepo _SessionInformationRepo;

        public GetSessionInformationByIdHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            ISessionInformationRepo sessionInformationRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _SessionInformationRepo = sessionInformationRepo;
        }

        public async Task<ActionResult<GetSessionInformationByIdResponse>> DoActionAsync(string id)
        {
            ActionResult<GetSessionInformationByIdResponse> result = new ActionResult<GetSessionInformationByIdResponse>();

            //Get Data
            SessionInformation entity = await _SessionInformationRepo.GetByIdAsync(id);

            if (entity == null)
            {
                result.IsNotFound = true;
                return result;
            }

            GetSessionInformationByIdResponse.ConfigMapping();
            result.Result = entity.Adapt<GetSessionInformationByIdResponse>();

            return result;
        }
    }
}
