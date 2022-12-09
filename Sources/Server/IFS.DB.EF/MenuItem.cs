using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            MenuDefinitions = new HashSet<MenuDefinition>();
            MenuPermissions = new HashSet<MenuPermission>();
            MenusResources = new HashSet<MenusResource>();
        }

        public int MenuItemId { get; set; }
        public string MenuItemType { get; set; } = null!;
        public bool? Administrators { get; set; }
        public bool? Users { get; set; }
        public bool? Customer { get; set; }
        public bool? Branch { get; set; }
        public bool? Host { get; set; }
        public bool? GroupHeader { get; set; }
        public bool? Mse { get; set; }
        public bool? Sse { get; set; }
        public string? Link { get; set; }
        public bool OnlyIfCustomerSelected { get; set; }
        public string? HelpPageId { get; set; }

        public virtual ICollection<MenuDefinition> MenuDefinitions { get; set; }
        public virtual ICollection<MenuPermission> MenuPermissions { get; set; }
        public virtual ICollection<MenusResource> MenusResources { get; set; }
    }
}
