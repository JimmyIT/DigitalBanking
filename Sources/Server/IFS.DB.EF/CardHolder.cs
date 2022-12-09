using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class CardHolder
    {
        public CardHolder()
        {
            CardHolderDetails = new HashSet<CardHolderDetail>();
        }

        public int RecordId { get; set; }
        public int CardDetailsRecordId { get; set; }

        public virtual CardDetail CardDetailsRecord { get; set; } = null!;
        public virtual ICollection<CardHolderDetail> CardHolderDetails { get; set; }
    }
}
