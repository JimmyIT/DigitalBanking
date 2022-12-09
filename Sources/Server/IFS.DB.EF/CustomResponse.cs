using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class CustomResponse
    {
        public string FileName { get; set; } = null!;
        public string? SentWhen { get; set; }
        public string? Description { get; set; }
    }
}
