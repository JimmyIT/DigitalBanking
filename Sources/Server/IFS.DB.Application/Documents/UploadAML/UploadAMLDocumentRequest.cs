using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Documents.UploadAML
{
    public class UploadAMLDocumentRequest
    {
        public Guid ApplicationId { get; set; }
        public Guid AmlRefId { get; set; }
        public string FileName { get; set; }
        public string DocumentCode { get; set; }
        public string Reference { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
