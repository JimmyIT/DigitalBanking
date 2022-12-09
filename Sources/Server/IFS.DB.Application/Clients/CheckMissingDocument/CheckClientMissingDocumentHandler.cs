using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.Customers;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.AMLtrac.Customers.CheckMissingDocument;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Clients.CheckMissingDocument
{
    public interface ICheckClientMissingDocumentHandler : IBaseHandler
    {
        Task<ActionResult<CheckClientMissingDocumentResponse>> DoActionAsync(CheckClientMissingDocumentRequest client);
    }

    public class CheckClientMissingDocumentHandler : BaseHandler, ICheckClientMissingDocumentHandler
    {
        private readonly ICheckClientMissingDocumentValidator _Validator;
        private readonly ICheckCustomerMissingDocumentService _CheckCustomerMissingDocumentSvc;

        public CheckClientMissingDocumentHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ICheckClientMissingDocumentValidator validator,
            ICheckCustomerMissingDocumentService checkCustomerMissingDocumentSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _CheckCustomerMissingDocumentSvc = checkCustomerMissingDocumentSvc;
        }

        public async Task<ActionResult<CheckClientMissingDocumentResponse>> DoActionAsync(CheckClientMissingDocumentRequest client)
        {
            ActionResult<CheckClientMissingDocumentResponse> result = new ActionResult<CheckClientMissingDocumentResponse>()
            {
                Result = new CheckClientMissingDocumentResponse() 
                { 
                    AMLtracRefId = client.AMLtracRefId,
                    IsCompleted = false
                }
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
            ActionResult<CheckCustomerMissingDocumentResponse> amlResult = await _CheckCustomerMissingDocumentSvc.DoActionAsync(client.AMLtracRefId);
            if (!amlResult.IsNotError)
            {
                result.Validation = amlResult.Validation;
                return result;
            }

            result.Result.IsCompleted = amlResult.Result.IsCompleted;

            return result;
        }
    }
}
