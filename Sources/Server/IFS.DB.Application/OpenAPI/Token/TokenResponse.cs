using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.OpenAPI.Token
{
    public class TokenResponse
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public int Expries_in { get; set; }
    }
}
