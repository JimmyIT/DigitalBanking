using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class UpgradeHistory
    {
        public float UpgradeTo { get; set; }
        public float UpgradedFrom { get; set; }
        public DateTime DateApplied { get; set; }
        public string ReleaseNotes { get; set; } = null!;
        public string UpgradeFileContents { get; set; } = null!;
    }
}
