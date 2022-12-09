using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class SiteSpecificHtmlcode
    {
        public SiteSpecificHtmlcode()
        {
            SiteSpecificHtmlvalues = new HashSet<SiteSpecificHtmlvalue>();
        }

        public int SiteSpecificHtmlcodesId { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<SiteSpecificHtmlvalue> SiteSpecificHtmlvalues { get; set; }
    }
}
