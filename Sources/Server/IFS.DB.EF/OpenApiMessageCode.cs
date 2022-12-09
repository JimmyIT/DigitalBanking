using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class OpenApiMessageCode
    {
        public OpenApiMessageCode()
        {
            OpenApiMessages = new HashSet<OpenApiMessage>();
        }

        public string MessageCode { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<OpenApiMessage> OpenApiMessages { get; set; }
    }
}
