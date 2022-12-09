using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class UILanguageResource
    {
        public string LanguageCode { get; set; } = null!;
        public string ResourceKey { get; set; } = null!;
        public string? ResourceText { get; set; }

        public virtual LanguageCulture LanguageCodeNavigation { get; set; } = null!;
        public virtual UIResource ResourceKeyNavigation { get; set; } = null!;
    }
}
