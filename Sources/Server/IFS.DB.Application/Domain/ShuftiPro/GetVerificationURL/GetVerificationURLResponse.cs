using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.ShuftiPro.GetVerificationURL
{
    public class GetVerificationURLResponse
    {
        public string Reference { get; set; }
        public string VerificationURL { get; set; }
        public int ExpireTime { get; set; }
    }
}
