using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class LanguageCulture
    {
        public LanguageCulture()
        {
            SiteSpecificHtmlvalues = new HashSet<SiteSpecificHtmlvalue>();
            UILanguageResources = new HashSet<UILanguageResource>();
        }

        public string Code { get; set; } = null!;
        public string LanguageName { get; set; } = null!;
        public bool? Available { get; set; }

        public virtual ICollection<SiteSpecificHtmlvalue> SiteSpecificHtmlvalues { get; set; }
        public virtual ICollection<UILanguageResource> UILanguageResources { get; set; }
    }
}
