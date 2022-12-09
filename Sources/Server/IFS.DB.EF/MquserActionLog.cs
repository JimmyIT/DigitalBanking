using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class MquserActionLog
    {
        public int RecordId { get; set; }
        public int UserActionTypeId { get; set; }
        public int MessageId { get; set; }
        public string? Note { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Mqmessage Message { get; set; } = null!;
        public virtual MquserActionType UserActionType { get; set; } = null!;
    }
}
