using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.TokenSale.KYC;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Domain.TokenSale.KYC.Approve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.NotifyKYCApprove
{
    public interface INotifyKYCApproveHandler : IBaseHandler
    {
        Task<ActionResult<NotifyKYCApproveResponse>> DoActionAsync(NotifyKYCApproveRequest kyc);
    }

    public class NotifyKYCApproveHandler : BaseHandler, INotifyKYCApproveHandler
    {
        private readonly INotifyKYCApproveValidator _Validator;
        private readonly IApproveKYCService _ApproveKYCSvc;

        public NotifyKYCApproveHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            INotifyKYCApproveValidator validator,
            IApproveKYCService approveKYCSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _ApproveKYCSvc = approveKYCSvc;
        }

        public async Task<ActionResult<NotifyKYCApproveResponse>> DoActionAsync(NotifyKYCApproveRequest kyc)
        {
            ActionResult<NotifyKYCApproveResponse> result = new ActionResult<NotifyKYCApproveResponse>()
            {
                Result = new NotifyKYCApproveResponse { Success = false}
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(kyc);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Create Token Sale Request
            ApproveKYCRequest approveKYCRequest = new ApproveKYCRequest()
            {
                LinkId = kyc.LinkId,
                RequestId = kyc.RequestId,
                AMLRefId = kyc.AMLRefId,
                Reference = kyc.Reference
            };

            //Call Token Sale API
            ActionResult<bool> tokenSaleResponse = await _ApproveKYCSvc.DoActionAsync(approveKYCRequest);
            if (!tokenSaleResponse.IsNotError)
            {
                result.Validation = tokenSaleResponse.Validation;
                return result;
            }

            result.Result.Success = tokenSaleResponse.Result;

            return result;
        }
    }
}
