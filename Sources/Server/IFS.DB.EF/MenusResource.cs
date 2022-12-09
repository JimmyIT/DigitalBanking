using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class MenusResource
    {
        public int MenuItemId { get; set; }
        public string LanguageCultureId { get; set; } = null!;
        public string DisplayText { get; set; } = null!;

        public virtual MenuItem MenuItem { get; set; } = null!;
    }
}
