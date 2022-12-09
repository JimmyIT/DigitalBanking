using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ProductCode
    {
        public string ProductCode1 { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string NewMessageType { get; set; } = null!;
        public string AmendMessageType { get; set; } = null!;
        public string CancelMessageType { get; set; } = null!;
        public bool RequiresValidation { get; set; }
        public bool RequiresVerification { get; set; }
        public bool IsAmountBased { get; set; }
    }
}
