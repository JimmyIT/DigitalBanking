using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ShoppingCart
    {
        public int RecordId { get; set; }
        public string? SessionId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Price { get; set; }
    }
}
