using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ImportMetaDatum
    {
        public string? InputFilename { get; set; }
        public string? OutputFilename { get; set; }
        public string? FieldName { get; set; }
        public int? FieldStart { get; set; }
        public int? FieldEnd { get; set; }
        public string? DataType { get; set; }
        public int? DataLength { get; set; }
        public int? RecordId { get; set; }
        public int ImportMetaDataId { get; set; }
        public Guid? HostId { get; set; }

        public virtual Host? Host { get; set; }
    }
}
