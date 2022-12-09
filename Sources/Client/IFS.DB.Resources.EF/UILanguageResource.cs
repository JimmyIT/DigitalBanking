using System;
using System.Collections.Generic;

namespace IFS.DB.Resources.EF
{
    public partial class UILanguageResource
    {
        public string LanguageCode { get; set; } = null!;
        public string ResourceKey { get; set; } = null!;
        public string? ResourceText { get; set; }
    }
}
