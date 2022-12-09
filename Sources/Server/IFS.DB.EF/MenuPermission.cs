using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class MenuPermission
    {
        public int MenuPermissionId { get; set; }
        public int MenuItemId { get; set; }
        public short PermissionTypeId { get; set; }
        public string? ValueId { get; set; }
        public bool? Available { get; set; }

        public virtual MenuItem MenuItem { get; set; } = null!;
        public virtual MenuPermissionType PermissionType { get; set; } = null!;
    }
}
