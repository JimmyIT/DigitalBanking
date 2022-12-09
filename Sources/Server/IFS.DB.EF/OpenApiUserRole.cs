using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class OpenApiUserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual OpenApiRole Role { get; set; } = null!;
        public virtual OpenApiUser User { get; set; } = null!;
    }
}
