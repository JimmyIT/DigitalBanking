using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Client.Documents.GetAMLRules
{
    public class GetAMLDocumentRulesByEntityTypeResponse
    {
        public string MinimumDocumentFormula { get; set; }
        public List<ProofCode> ProofCodes { get; set; }
        public List<DocumentType> DocumentTypes { get; set; }
    }

    public class ProofCode
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class DocumentType
    {
        public int DocumentId { get; set; }
        public string DocumentCode { get; set; }
        public string Name { get; set; }
        public bool IsReferenced { get; set; }
        public bool CanExpire { get; set; }
        public int Point { get; set; }
        public bool IsDocOriginRequired { get; set; }
        public string ProofCode { get; set; }
        public string Country { get; set; }
        public string VerificationType { get; set; }
        public string VerificationChannel { get; set; }
    }
}
