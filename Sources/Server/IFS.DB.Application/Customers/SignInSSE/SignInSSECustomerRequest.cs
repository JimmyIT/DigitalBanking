using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Customers.SignInSSE
{
    public class SignInSSECustomerRequest
    {
        public string InternalId { get; set; }
        public IList<PasswordCharacter> PasswordCharacters { get; set; }
        public string SecurityCode { get; set; }
    }

    public class PasswordCharacter
    {
        public int Position { get; set; }
        public string Keyword { get; set; }
    }
}
