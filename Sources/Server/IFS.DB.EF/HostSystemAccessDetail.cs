using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class HostSystemAccessDetail
    {
        public Guid HostSystemId { get; set; }
        public string AccessId { get; set; } = null!;
        public string AccessCode { get; set; } = null!;
        public string HostSystemLiteral { get; set; } = null!;
    }
}
