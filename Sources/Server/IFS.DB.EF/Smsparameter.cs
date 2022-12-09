using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Smsparameter
    {
        public string ParameterId { get; set; } = null!;
        public string? Description { get; set; }
        public string? FailAs { get; set; }
    }
}
