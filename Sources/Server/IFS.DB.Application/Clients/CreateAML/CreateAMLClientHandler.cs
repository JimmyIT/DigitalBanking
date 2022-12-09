using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.Customers;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.AMLtrac.Customers.Import;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.Results;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Clients.CreateAML
{
    public interface ICreateAMLClientHandler : IBaseHandler
    {
        Task<ActionResult<CreateAMLClientResponse>> DoActionAsync(CreateAMLClientRequest client);
    }

    public class CreateAMLClientHandler : BaseHandler, ICreateAMLClientHandler
    {
        private readonly ICreateAMLClientValidator _Validator;
        private readonly IImportCustomerService _ImportCustomerSvc;

        public CreateAMLClientHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ICreateAMLClientValidator validator,
            IImportCustomerService importCustomerSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _ImportCustomerSvc = importCustomerSvc;
        }

        public async Task<ActionResult<CreateAMLClientResponse>> DoActionAsync(CreateAMLClientRequest client)
        {
            ActionResult<CreateAMLClientResponse> result = new ActionResult<CreateAMLClientResponse>()
            {
                Result = new CreateAMLClientResponse() 
                { 
                    EmailAddress = client.EmailAddress,
                    DataItemID = client.DataItemID,
                    AMLtracRefId = string.Empty,
                    Status = AMLCustomerStatusEnum.Unknown
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

            //Create AML Request Model
            ImportCustomerRequest amlClient = client.Adapt<ImportCustomerRequest>();

            //Call AMLtrac API to Create Client
            ActionResult<ImportCustomerResponse> createResult = await _ImportCustomerSvc.DoActionAsync(amlClient);
            if (!createResult.IsNotError)
            {
                result.Validation = createResult.Validation;
                return result;
            }

            result.Result.AMLtracRefId = createResult.Result.AMLtracRefId;
            
            return result;
        }
    }
}
