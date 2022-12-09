using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class CountryCode
    {
        public CountryCode()
        {
            SmssystemDefaults = new HashSet<SmssystemDefault>();
        }

        public string CountryCode1 { get; set; } = null!;
        public short? DialingCode { get; set; }
        public string? Description { get; set; }
        public string? CurrencyCode { get; set; }
        public string? Iddcode { get; set; }
        public string? NationalPrefix { get; set; }

        public virtual Currency? CurrencyCodeNavigation { get; set; }
        public virtual ICollection<SmssystemDefault> SmssystemDefaults { get; set; }
    }
}
