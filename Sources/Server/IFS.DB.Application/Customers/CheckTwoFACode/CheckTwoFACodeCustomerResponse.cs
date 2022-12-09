using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Customers.CheckTwoFACode
{
    public class CheckTwoFACodeCustomerResponse
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpriesIn { get; set; }
    }
}
