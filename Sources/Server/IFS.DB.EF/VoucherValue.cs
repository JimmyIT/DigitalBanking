using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class VoucherValue
    {
        public string VoucherId { get; set; } = null!;
        public decimal Value { get; set; }
        public string? Notes { get; set; }

        public virtual Voucher Voucher { get; set; } = null!;
    }
}
