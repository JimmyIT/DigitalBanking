using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Bankware.Clients.CheckEmailExist
{
    public class CheckEmailExistResponse
    {
        public string EmailAddress { get; set; }
        public bool IsExist { get; set; }
    }
}
