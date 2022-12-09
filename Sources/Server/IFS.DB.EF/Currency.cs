using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Currency
    {
        public Currency()
        {
            Accounts = new HashSet<Account>();
            CountryCodes = new HashSet<CountryCode>();
        }

        public string CurrencyCode { get; set; } = null!;
        public string CurrencyName { get; set; } = null!;
        public int DecimalPlaces { get; set; }
        public int PaymentDaysNotice { get; set; }
        public DateTime? CutOffTime { get; set; }
        public int SortOrder { get; set; }
        public bool? AllowInternationalPayments { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<CountryCode> CountryCodes { get; set; }
    }
}
