using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ImportedBacspaymentFile
    {
        public int ImportedFileId { get; set; }
        public string IBankReference { get; set; } = null!;
        public string ImportedBy { get; set; } = null!;
        public DateTime ImportedOn { get; set; }
        public string FileName { get; set; } = null!;
        public int FileSize { get; set; }
        public byte[] FileContent { get; set; } = null!;
    }
}
