using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class OpenApiRole
    {
        public OpenApiRole()
        {
            OpenApiUserRoles = new HashSet<OpenApiUserRole>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<OpenApiUserRole> OpenApiUserRoles { get; set; }
    }
}
