using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class MenuStructure
    {
        public int MenuStructureId { get; set; }
        public int MenuItemId { get; set; }
        public int MenuLevel { get; set; }
        public int OrderInLevel { get; set; }
        public int? ParentMenu { get; set; }
    }
}
