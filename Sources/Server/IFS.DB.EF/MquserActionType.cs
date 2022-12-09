using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class MquserActionType
    {
        public MquserActionType()
        {
            MquserActionLogs = new HashSet<MquserActionLog>();
        }

        public int UserActionTypeId { get; set; }
        public string ActionName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<MquserActionLog> MquserActionLogs { get; set; }
    }
}
