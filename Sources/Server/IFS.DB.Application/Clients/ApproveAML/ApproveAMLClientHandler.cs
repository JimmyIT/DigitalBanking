using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.Customers;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Clients.ApproveAML
{
    public interface IApproveAMLClientHandler : IBaseHandler
    {
        Task<ActionResult<ApproveAMLClientResponse>> DoActionAsync(ApproveAMLClientRequest client);
    }

    public class ApproveAMLClientHandler : BaseHandler, IApproveAMLClientHandler
    {
        private readonly IApproveAMLClientValidator _Validator;
        private readonly IApproveCustomerService _ApproveCustomerSvc;

        public ApproveAMLClientHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IApproveAMLClientValidator validator,
            IApproveCustomerService approveCustomerSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _ApproveCustomerSvc = approveCustomerSvc;
        }

        public async Task<ActionResult<ApproveAMLClientResponse>> DoActionAsync(ApproveAMLClientRequest client)
        {
            ActionResult<ApproveAMLClientResponse> result = new ActionResult<ApproveAMLClientResponse>()
            {
                Result = new ApproveAMLClientResponse() { ApplicationId = client.ApplicationId }
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
            ActionResult<string> amlResult = await _ApproveCustomerSvc.DoActionAsync(client.ApplicationId);
            if (!amlResult.IsNotError)
            {
                result.Validation = amlResult.Validation;
                return result;
            }

            return result;
        }
    }
}
