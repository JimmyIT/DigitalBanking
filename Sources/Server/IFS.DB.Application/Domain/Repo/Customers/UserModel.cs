using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Repo.Customers
{
    public class UserModel
    {
        public UserProfile Profile { get; set; }
        public string PIN { get; set; }
        public string Password { get; set; }
    }
}
