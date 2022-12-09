using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class UnallocatedReceipt
    {
        public UnallocatedReceipt()
        {
            ReceiptAllocations = new HashSet<ReceiptAllocation>();
        }

        public int ReceiptId { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal ReceiptTotal { get; set; }
        public decimal UnallocatedTotal { get; set; }
        public decimal PostedTotal { get; set; }
        public decimal UnpostedTotal { get; set; }
        public int Status { get; set; }

        public virtual ICollection<ReceiptAllocation> ReceiptAllocations { get; set; }
    }
}
