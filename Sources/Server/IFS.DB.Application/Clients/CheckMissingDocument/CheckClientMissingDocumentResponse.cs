using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Clients.CheckMissingDocument
{
    public class CheckClientMissingDocumentResponse
    {
        public Guid AMLtracRefId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
