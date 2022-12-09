using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common;
using IFS.DB.Application.Common.ShuftiPro;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Domain.ShuftiPro.GetVerificationStatus;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Documents.GetShuftiProVerificationStatus
{
    public interface IGetShuftiProVerificationStatusHandler : IBaseHandler
    {
        Task<ActionResult<GetShuftiProVerificationStatusResponse>> DoActionAsync(string reference);
    }

    public class GetShuftiProVerificationStatusHandler : BaseHandler, IGetShuftiProVerificationStatusHandler
    {
        private readonly IGetShuftiProVerificationStatusValidator _Validator;
        private readonly IGetVerificationStatusService _GetVerificationStatusSvc;

        public GetShuftiProVerificationStatusHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator, 
            IGetShuftiProVerificationStatusValidator validator,
            IGetVerificationStatusService getVerificationStatusSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _GetVerificationStatusSvc = getVerificationStatusSvc;
        }

        public async Task<ActionResult<GetShuftiProVerificationStatusResponse>> DoActionAsync(string reference)
        {
            ActionResult<GetShuftiProVerificationStatusResponse> result = new ActionResult<GetShuftiProVerificationStatusResponse>()
            {
                Result = new GetShuftiProVerificationStatusResponse() {  }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(reference);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            ActionResult<GetVerificationStatusResponse> responseObj = await _GetVerificationStatusSvc.DoActionAsync(reference);

            if (responseObj.IsNotError)
                result.Result = responseObj.Result.Adapt<GetShuftiProVerificationStatusResponse>();
            else
                result.Validation = responseObj.Validation;

            return result;
        }
    }
}
