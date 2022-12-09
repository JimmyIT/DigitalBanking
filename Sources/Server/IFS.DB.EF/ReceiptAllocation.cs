using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ReceiptAllocation
    {
        public int ReceiptAllocationId { get; set; }
        public int ReceiptId { get; set; }
        public string AccountId { get; set; } = null!;
        public decimal AllocatedAmount { get; set; }
        public DateTime AllocationDate { get; set; }
        public int Status { get; set; }

        public virtual UnallocatedReceipt Receipt { get; set; } = null!;
    }
}
