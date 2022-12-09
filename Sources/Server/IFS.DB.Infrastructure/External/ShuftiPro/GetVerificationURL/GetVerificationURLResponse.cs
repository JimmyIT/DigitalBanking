using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.External.ShuftiPro.GetVerificationURL
{
    public class GetVerificationURLResponse
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("verification_url")]
        public string VerificationURL { get; set; }
    }
}
