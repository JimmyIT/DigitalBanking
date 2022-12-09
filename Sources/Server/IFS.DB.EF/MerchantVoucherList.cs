using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class MerchantVoucherList
    {
        public string ClientId { get; set; } = null!;
        public string VoucherId { get; set; } = null!;
        public bool Issuer { get; set; }
        public bool Redeemer { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Voucher Voucher { get; set; } = null!;
    }
}
