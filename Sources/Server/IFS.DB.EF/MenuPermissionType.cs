using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class MenuPermissionType
    {
        public MenuPermissionType()
        {
            MenuPermissions = new HashSet<MenuPermission>();
        }

        public short PermissionTypeId { get; set; }
        public string PermissionType { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<MenuPermission> MenuPermissions { get; set; }
    }
}
