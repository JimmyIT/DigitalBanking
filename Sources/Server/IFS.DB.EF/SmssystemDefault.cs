using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class SmssystemDefault
    {
        public string SystemId { get; set; } = null!;
        public decimal? MaxBalanceCustomer { get; set; }
        public decimal? MaxBalanceRetailer { get; set; }
        public decimal? MaxBalanceMerchant { get; set; }
        public decimal? MaxBalanceIntroducer { get; set; }
        public decimal? MaxBalanceNetworkOperator { get; set; }
        public short? YearEndMonth { get; set; }
        public string? Iddsymbol { get; set; }
        public string? Iddcode { get; set; }
        public string? CountryCode { get; set; }
        public string? PrimaryCashVoucherId { get; set; }
        public string? WelcomeMessageSmscode { get; set; }
        public string? ChargesAccount { get; set; }
        public string? CommisionsAccount { get; set; }
        public string? MasterClientId { get; set; }
        public short? DefaultPollFrequency { get; set; }
        public string? NoClientSmscode { get; set; }
        public string? InvalidMessageSmscode { get; set; }
        public string? CrossCcyAccount { get; set; }

        public virtual CountryCode? CountryCodeNavigation { get; set; }
        public virtual Sccgateway Sccgateway { get; set; } = null!;
    }
}
