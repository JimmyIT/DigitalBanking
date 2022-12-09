using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            BatchItems = new HashSet<BatchItem>();
            CustomerPayments = new HashSet<CustomerPayment>();
            ReleasedBatchItemHistories = new HashSet<ReleasedBatchItemHistory>();
        }

        public int PaymenTypeId { get; set; }
        public string PaymentType1 { get; set; } = null!;
        public int PaymentTypeValue { get; set; }
        public string Description { get; set; } = null!;
        public string ShortCode { get; set; } = null!;
        public bool? IsDomestic { get; set; }
        public string IbcproductCode { get; set; } = null!;
        public bool? Available { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<BatchItem> BatchItems { get; set; }
        public virtual ICollection<CustomerPayment> CustomerPayments { get; set; }
        public virtual ICollection<ReleasedBatchItemHistory> ReleasedBatchItemHistories { get; set; }
    }
}
