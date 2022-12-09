using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Documents.GetShuftiProVerificationURL
{
    public class GetShuftiProVerificationURLResponse
    {
        public Guid ApplicationId { get; set; }
        public string VerificationURL { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
