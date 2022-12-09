using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Documents.GetShuftiProVerificationURL
{
    public class GetShuftiProVerificationURLResponse
    {
        public Guid ApplicationId { get; set; }
        public string VerificationURL { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
