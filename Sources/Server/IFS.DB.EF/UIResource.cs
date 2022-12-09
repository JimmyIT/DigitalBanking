using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class UIResource
    {
        public UIResource()
        {
            UILanguageResources = new HashSet<UILanguageResource>();
        }

        public string ResourceKey { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<UILanguageResource> UILanguageResources { get; set; }
    }
}
