using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.OpenAPI.Token
{
    public class TokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
