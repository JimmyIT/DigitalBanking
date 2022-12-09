using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Voucher
    {
        public Voucher()
        {
            MerchantVoucherLists = new HashSet<MerchantVoucherList>();
            VoucherValues = new HashSet<VoucherValue>();
        }

        public string VoucherId { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string VoucherType { get; set; } = null!;
        public bool InternalOnly { get; set; }
        public bool SpecificProcessing { get; set; }
        public bool SetValuePurchase { get; set; }
        public bool SetValueRedeem { get; set; }
        public bool SetValueTransfer { get; set; }

        public virtual ICollection<MerchantVoucherList> MerchantVoucherLists { get; set; }
        public virtual ICollection<VoucherValue> VoucherValues { get; set; }
    }
}
