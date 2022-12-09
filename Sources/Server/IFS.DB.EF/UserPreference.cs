using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class UserPreference
    {
        public string InternalId { get; set; } = null!;
        public string LogonId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string StartPage { get; set; } = null!;
        public string DateFormat { get; set; } = null!;
        public string DateFormatChecked { get; set; } = null!;
        public string ToolbarPosition { get; set; } = null!;
        public string RequireDigitalCertificate { get; set; } = null!;
        public bool? DisplayInstructions { get; set; }
        public bool ShowMultipleNarrativesByDefault { get; set; }
        public string? EmailAddress { get; set; }
        public bool EmailNotificationHigh { get; set; }
        public bool EmailNotificationNormal { get; set; }
        public bool EmailNotificationLow { get; set; }
    }
}
