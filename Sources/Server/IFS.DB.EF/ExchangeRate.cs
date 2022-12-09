using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ExchangeRate
    {
        public string Currency1 { get; set; } = null!;
        public string Currency2 { get; set; } = null!;
        public string Operand { get; set; } = null!;
        public decimal BuyCurrency1Rate { get; set; }
        public decimal SellCurrency1Rate { get; set; }
    }
}
