using IFS.DB.Application.Common.AMLtrac.Documents;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.AMLtrac.Documents.Upload;
using IFS.DB.Application.Domain.Results;
using IFS.MLTrac.OpenAPI.ClientConfig;
using IFS.MLTrac.OpenAPI.ClientConfig.Models.KYC.Documentation.UploadDocument;

namespace IFS.DB.Infrastructure.External.AMLtrac.Documents.Upload
{
    public class UploadDocumentService : BaseAMLtracOpenAPIService, IUploadDocumentService
    {
        public UploadDocumentService(IParameterService parameterSvc)
           : base(parameterSvc)
        {
        }

        public async Task<ActionResult<bool>> DoActionAsync(UploadDocumentRequest document)
        {
            ActionResult<bool> result = new ActionResult<bool> { Result = false };

            MultipartFormDataContent multipartFormContent = new MultipartFormDataContent();

            //Add another content
            multipartFormContent.Add(new StringContent(document.DocumentCode), name: "DocumentCode");
            multipartFormContent.Add(new StringContent(document.Reference), name: "Reference");
            multipartFormContent.Add(new StringContent(document.ExpiryDate.ToString()), name: "ExpiryDate");

            //Add File
            StreamContent fileStreamContent = new StreamContent(File.OpenRead(document.FullPath));
            multipartFormContent.Add(fileStreamContent, name: "file", fileName: document.FileName);

            string apiPath = OpenApiEndpoints.Ver2.AmlEntities.UploadDocumentation.Replace(@"{entityGuid}", document.AmlRefId.ToString());

            ActionResult<DocumentationCreationResponse> amlResult = await PostMultiPartFormAsync<DocumentationCreationResponse>(apiPath, multipartFormContent);
            
            if (!amlResult.IsNotError)
            {
                result.Validation = amlResult.Validation;
                return result;
            }

            result.Result = amlResult.Result.DocumentObjectId != 0;

            return result;
        }
    }
}
