using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.OpenAPI.Token
{
    public class TokenResponse
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public int Expries_in { get; set; }
    }
}
