using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class SiteSpecificHtmlvalue
    {
        public int SiteSpecificHtmlvaluesId { get; set; }
        public int SiteSpecificHtmlcodesId { get; set; }
        public string LanguageCultureId { get; set; } = null!;
        public string Value { get; set; } = null!;

        public virtual LanguageCulture LanguageCulture { get; set; } = null!;
        public virtual SiteSpecificHtmlcode SiteSpecificHtmlcodes { get; set; } = null!;
    }
}
