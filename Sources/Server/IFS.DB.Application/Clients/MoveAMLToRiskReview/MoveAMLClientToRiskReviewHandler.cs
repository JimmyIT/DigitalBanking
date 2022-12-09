using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.Customers;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Clients.MoveAMLToRiskReview
{
    public interface IMoveAMLClientToRiskReviewHandler : IBaseHandler
    {
        Task<ActionResult<MoveAMLClientToRiskReviewResponse>> DoActionAsync(MoveAMLClientToRiskReviewRequest client);
    }

    public class MoveAMLClientToRiskReviewHandler : BaseHandler, IMoveAMLClientToRiskReviewHandler
    {
        private readonly IMoveAMLClientToRiskReviewValidator _Validator;
        private readonly IMoveCustomerToRiskReviewService _MoveCustomerToRiskReviewSvc;

        public MoveAMLClientToRiskReviewHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IMoveAMLClientToRiskReviewValidator validator,
            IMoveCustomerToRiskReviewService moveCustomerToRiskReviewSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _MoveCustomerToRiskReviewSvc = moveCustomerToRiskReviewSvc;
        }

        public async Task<ActionResult<MoveAMLClientToRiskReviewResponse>> DoActionAsync(MoveAMLClientToRiskReviewRequest client)
        {
            ActionResult<MoveAMLClientToRiskReviewResponse> result = new ActionResult<MoveAMLClientToRiskReviewResponse>()
            {
                Result = new MoveAMLClientToRiskReviewResponse() { Success = false }
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
            ActionResult<bool> amlResult = await _MoveCustomerToRiskReviewSvc.DoActionAsync(client.AmlRefId);
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
