using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class MenuDefinition
    {
        public int MenuStructureId { get; set; }
        public int Level1 { get; set; }
        public int? Level2 { get; set; }
        public int? Level3 { get; set; }
        public int? MenuItemId { get; set; }

        public virtual MenuItem? MenuItem { get; set; }
    }
}
