using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Host
    {
        public Host()
        {
            ImportMetaData = new HashSet<ImportMetaDatum>();
            ImportParameters = new HashSet<ImportParameter>();
        }

        public Guid HostId { get; set; }
        public string HostName { get; set; } = null!;
        public string AccessId { get; set; } = null!;
        public string AccessCode { get; set; } = null!;
        public string HostWebserviceUrl { get; set; } = null!;

        public virtual ICollection<ImportMetaDatum> ImportMetaData { get; set; }
        public virtual ICollection<ImportParameter> ImportParameters { get; set; }
    }
}
