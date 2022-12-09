using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.Customers;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Clients.MoveAMLToDataCapture
{
    public interface IMoveAMLClientToDataCaptureHandler : IBaseHandler
    {
        Task<ActionResult<MoveAMLClientToDataCaptureResponse>> DoActionAsync(MoveAMLClientToDataCaptureRequest client);
    }

    public class MoveAMLClientToDataCaptureHandler : BaseHandler, IMoveAMLClientToDataCaptureHandler
    {
        private readonly IMoveAMLClientToDataCaptureValidator _Validator;
        private readonly IMoveCustomerToDataCaptureService _MoveCustomerToDataCaptureSvc;

        public MoveAMLClientToDataCaptureHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IMoveAMLClientToDataCaptureValidator validator,
            IMoveCustomerToDataCaptureService moveCustomerToDataCaptureSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _MoveCustomerToDataCaptureSvc = moveCustomerToDataCaptureSvc;
        }

        public async Task<ActionResult<MoveAMLClientToDataCaptureResponse>> DoActionAsync(MoveAMLClientToDataCaptureRequest client)
        {
            ActionResult<MoveAMLClientToDataCaptureResponse> result = new ActionResult<MoveAMLClientToDataCaptureResponse>()
            {
                Result = new MoveAMLClientToDataCaptureResponse() { Success = false }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(client);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Call AMLtrac API to Create Client
            ActionResult<bool> amlResult = await _MoveCustomerToDataCaptureSvc.DoActionAsync(client.AmlRefId);
            if (!amlResult.IsNotError)
            {
                result.Validation = amlResult.Validation;
                return result;
            }

            result.Result.Success = amlResult.Result;

            return result;
        }
    }
}
