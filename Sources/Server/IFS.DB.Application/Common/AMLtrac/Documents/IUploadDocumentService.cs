using IFS.DB.Application.Domain.AMLtrac.Documents.Upload;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.AMLtrac.Documents
{
    public interface IUploadDocumentService
    {
        Task<ActionResult<bool>> DoActionAsync(UploadDocumentRequest document);
    }
}
