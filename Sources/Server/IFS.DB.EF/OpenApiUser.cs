using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class OpenApiUser
    {
        public OpenApiUser()
        {
            OpenApiUserRoles = new HashSet<OpenApiUserRole>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Status { get; set; }

        public virtual ICollection<OpenApiUserRole> OpenApiUserRoles { get; set; }
    }
}
