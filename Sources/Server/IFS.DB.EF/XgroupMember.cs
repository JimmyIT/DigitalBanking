using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class XgroupMember
    {
        public string? InternalId { get; set; }
        public string? GroupId { get; set; }
        public string? OriginalGroupId { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredOn { get; set; }
        public int GroupMemberId { get; set; }
    }
}
