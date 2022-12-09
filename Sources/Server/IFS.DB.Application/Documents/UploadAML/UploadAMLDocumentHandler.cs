using IFS.DB.Application.Common;
using IFS.DB.Application.Common.AMLtrac.Documents;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.AMLtrac.Documents.Upload;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Documents.UploadAML
{
    public interface IUploadAMLDocumentHandler : IBaseHandler
    {
        Task<ActionResult<UploadAMLDocumentResponse>> DoActionAsync(UploadAMLDocumentRequest document);
    }

    public class UploadAMLDocumentHandler : BaseHandler, IUploadAMLDocumentHandler
    {
        private readonly IUploadAMLDocumentValidator _Validator;
        private readonly IParameterService _ParameterSvc;
        private readonly IUploadDocumentService _UploadDocumentSvc;

        public UploadAMLDocumentHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IUploadAMLDocumentValidator validator,
            IParameterService parameterSvc,
            IUploadDocumentService uploadDocumentSvc)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _ParameterSvc = parameterSvc;
            _UploadDocumentSvc = uploadDocumentSvc;
        }

        public async Task<ActionResult<UploadAMLDocumentResponse>> DoActionAsync(UploadAMLDocumentRequest document)
        {
            ActionResult<UploadAMLDocumentResponse> result = new ActionResult<UploadAMLDocumentResponse>()
            {
                Result = new UploadAMLDocumentResponse() { Success = false }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(document);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Create AMltrac Model
            UploadDocumentRequest uploadDocRequest = new UploadDocumentRequest()
            {
                AmlRefId = document.AmlRefId,
                FullPath = $"{await _ParameterSvc.GetDocumentUploadFolderAsync()}\\{document.ApplicationId}\\{document.FileName}",
                FileName = document.FileName,
                DocumentCode = document.DocumentCode,
                Reference = document.Reference,
                ExpiryDate = document.ExpiryDate
            };

            //Call AMLtrac API
            ActionResult<bool> amlResult = await _UploadDocumentSvc.DoActionAsync(uploadDocRequest);
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
