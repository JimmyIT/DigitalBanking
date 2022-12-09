using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.ShuftiPro.GetVerificationURL
{
    public class GetVerificationURLRequest
    {
        public string Reference { get; set; }
        public string RedirectURL { get; set; }
        public List<string> DocumentType { get; set; }
        public List<string> AddressType { get; set; }
    }
}
