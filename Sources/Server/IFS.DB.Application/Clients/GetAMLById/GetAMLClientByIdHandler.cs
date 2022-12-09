using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.Customers;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.AMLtrac.Customers.GetLinkId;
using IFS.DB.Application.Domain.Results;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Clients.GetAMLById
{
    public interface IGetAMLClientByIdHandler : IBaseHandler
    {
        Task<ActionResult<GetAMLClientByIdResponse>> DoActionAsync(string amlRefId);
    }

    public class GetAMLClientByIdHandler : BaseHandler, IGetAMLClientByIdHandler
    {
        private readonly IGetAMLClientByIdValidator _Validator;
        private readonly IGetCustomerLinkIdService _GetCustomerLinkIdSvc;

        public GetAMLClientByIdHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IGetAMLClientByIdValidator validator,
            IGetCustomerLinkIdService getCustomerLinkIdSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _GetCustomerLinkIdSvc = getCustomerLinkIdSvc;
        }

        public async Task<ActionResult<GetAMLClientByIdResponse>> DoActionAsync(string amlRefId)
        {
            ActionResult<GetAMLClientByIdResponse> result = new ActionResult<GetAMLClientByIdResponse>()
            {
                Result = new GetAMLClientByIdResponse() { AMLtracRefId = amlRefId }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(amlRefId);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Get Data
            ActionResult<GetCustomerLinkIdResponse> responseObj = await _GetCustomerLinkIdSvc.DoActionAsync(amlRefId);

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<GetAMLClientByIdResponse>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }
    }
}
