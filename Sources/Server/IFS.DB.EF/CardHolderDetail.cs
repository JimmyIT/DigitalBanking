using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class CardHolderDetail
    {
        public int RecordId { get; set; }
        public int CardHoldersRecordId { get; set; }
        public short HolderId { get; set; }
        public short Status { get; set; }
        public string? Reason { get; set; }
        public string? MobilePhoneNumber { get; set; }

        public virtual CardHolder CardHoldersRecord { get; set; } = null!;
    }
}
