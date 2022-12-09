using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Clients.DeleteByClientNumbber
{
    public interface IDeleteClientByClientNumberHandler : IBaseHandler
    {
        Task<ActionResult<bool>> DoActionAsync(string clientNumber);
    }

    public class DeleteClientByClientNumberHandler : BaseHandler, IDeleteClientByClientNumberHandler
    {
        private readonly IClientRepo _ClientRepo;

        public DeleteClientByClientNumberHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IClientRepo clientRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _ClientRepo = clientRepo;
        }

        public async Task<ActionResult<bool>> DoActionAsync(string clientNumber)
        {
            ActionResult<bool> result = new ActionResult<bool>()
            {
                Result = false
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            await _ClientRepo.DeleteAsync(clientNumber);
            result.Result = true;

            return result;
        }
    }
}
