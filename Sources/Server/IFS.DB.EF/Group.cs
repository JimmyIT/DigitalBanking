using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Group
    {
        public string GroupId { get; set; } = null!;
        public string LogonId { get; set; } = null!;
        public string? Description { get; set; }
    }
}
