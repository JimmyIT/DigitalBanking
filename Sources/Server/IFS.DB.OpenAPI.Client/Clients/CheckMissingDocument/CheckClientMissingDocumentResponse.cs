using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Clients.CheckMissingDocument
{
    public class CheckClientMissingDocumentResponse
    {
        public Guid AMLtracRefId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
