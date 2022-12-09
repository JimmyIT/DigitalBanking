using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Customers.GetById
{
    public interface IGetCustomerByIdHandler : IBaseHandler
    {
        Task<ActionResult<GetCustomerByIdResponse>> DoActionAsync(string id);
    }

    public class GetCustomerByIdHandler : BaseHandler, IGetCustomerByIdHandler
    {
        private readonly ICustomerRepo _CustomerRepo;

        public GetCustomerByIdHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            ICustomerRepo customerRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _CustomerRepo = customerRepo;
        }

        public async Task<ActionResult<GetCustomerByIdResponse>> DoActionAsync(string id)
        {
            ActionResult<GetCustomerByIdResponse> result = new ActionResult<GetCustomerByIdResponse>();

            //Get Data
            IBankCustomer entity = await _CustomerRepo.GetByLogonId(id);

            if (entity == null)
            {
                result.IsNotFound = true;

                IList<Error> errors = new List<Error>();
                errors.Add(await _ErrorMessageSvc.CreateAsync(ErrorMessageCode.LogonIdInvalid));
                result.Validation = new ValidationResult(errors);

                return result;
            }

            result.Result = entity.Adapt<GetCustomerByIdResponse>();

            return result;
        }
    }
}
