using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ApiErrorResource
    {
        public string ResourceKey { get; set; } = null!;
        public string? Message { get; set; }
    }
}
