using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class MerchantCharge
    {
        public int MerchantChargeId { get; set; }
        public int ChargeId { get; set; }
        public decimal Value { get; set; }
        public decimal ChargeAmount { get; set; }
        public int ChargeOrder { get; set; }
    }
}
